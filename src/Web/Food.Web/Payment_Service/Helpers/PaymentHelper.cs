using System.Text;
using System.Web;

namespace Payment_Service.Helpers
{
    public static class PaymentHelper
    {
        /// <summary>
        /// Build query string cho VNPay - QUAN TR?NG: Ph?i sort theo th? t? alphabet
        /// </summary>
        public static string BuildQueryString(Dictionary<string, string> parameters)
        {
            // Sort parameters theo key (alphabet order)
            var sortedParams = parameters
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .OrderBy(x => x.Key)
                .ToList();

            var queryString = new StringBuilder();

            foreach (var param in sortedParams)
            {
                if (queryString.Length > 0)
                    queryString.Append("&");

                // KHÔNG URL ENCODE cho hash data
                queryString.Append($"{param.Key}={param.Value}");
            }

            return queryString.ToString();
        }

        /// <summary>
        /// Build query string có URL encode cho URL cu?i cùng
        /// </summary>
        public static string BuildQueryStringWithUrlEncode(Dictionary<string, string> parameters)
        {
            var sortedParams = parameters
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .OrderBy(x => x.Key)
                .ToList();

            var queryString = new StringBuilder();

            foreach (var param in sortedParams)
            {
                if (queryString.Length > 0)
                    queryString.Append("&");

                queryString.Append($"{param.Key}={HttpUtility.UrlEncode(param.Value)}");
            }

            return queryString.ToString();
        }

        public static Dictionary<string, string> ParseQueryString(string queryString)
        {
            var result = new Dictionary<string, string>();
            var pairs = queryString.Split('&');

            foreach (var pair in pairs)
            {
                var keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    result[HttpUtility.UrlDecode(keyValue[0])] = HttpUtility.UrlDecode(keyValue[1]);
                }
            }

            return result;
        }

        public static string FormatAmount(decimal amount)
        {
            // VNPay yêu c?u amount * 100 (VNÐ không có don v? xu)
            return ((long)(amount * 100)).ToString();
        }

        public static string GetVNPayResponseMessage(string responseCode)
        {
            return responseCode switch
            {
                "00" => "Giao d?ch thành công",
                "07" => "Tr? ti?n thành công. Giao d?ch b? nghi ng? (liên quan t?i l?a d?o, giao d?ch b?t thu?ng).",
                "09" => "Giao d?ch không thành công do: Th?/Tài kho?n c?a khách hàng chua dang ký d?ch v? InternetBanking t?i ngân hàng.",
                "10" => "Giao d?ch không thành công do: Khách hàng xác th?c thông tin th?/tài kho?n không dúng quá 3 l?n",
                "11" => "Giao d?ch không thành công do: Ðã h?t h?n ch? thanh toán. Xin quý khách vui lòng th?c hi?n l?i giao d?ch.",
                "12" => "Giao d?ch không thành công do: Th?/Tài kho?n c?a khách hàng b? khóa.",
                "13" => "Giao d?ch không thành công do Quý khách nh?p sai m?t kh?u xác th?c giao d?ch (OTP).",
                "24" => "Giao d?ch không thành công do: Khách hàng h?y giao d?ch",
                "51" => "Giao d?ch không thành công do: Tài kho?n c?a quý khách không d? s? du d? th?c hi?n giao d?ch.",
                "65" => "Giao d?ch không thành công do: Tài kho?n c?a Quý khách dã vu?t quá h?n m?c giao d?ch trong ngày.",
                "75" => "Ngân hàng thanh toán dang b?o trì.",
                "79" => "Giao d?ch không thành công do: KH nh?p sai m?t kh?u thanh toán quá s? l?n quy d?nh.",
                _ => "Giao d?ch th?t b?i"
            };
        }

        public static string GetIpAddress(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = context.Connection.RemoteIpAddress?.ToString();
            }
            return ipAddress ?? "127.0.0.1";
        }
    }
}
