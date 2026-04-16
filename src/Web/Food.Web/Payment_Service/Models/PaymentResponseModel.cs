using Payment_Service.Enums;

namespace Payment_Service.Models
{
    /// <summary>
    /// Model cho response thanh toán
    /// </summary>
    public class PaymentResponseModel
    {
        /// <summary>
        /// Mã giao d?ch
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Mã don hàng
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// S? ti?n thanh toán
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Phuong th?c thanh toán
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Tr?ng thái thanh toán
        /// </summary>
        public PaymentStatus Status { get; set; }

        /// <summary>
        /// Thành công hay không
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Thông báo
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// URL thanh toán (cho MoMo, VNPay)
        /// </summary>
        public string PaymentUrl { get; set; }

        /// <summary>
        /// QR Code URL (cho MoMo)
        /// </summary>
        public string QrCodeUrl { get; set; }

        /// <summary>
        /// Mã l?i
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Th?i gian t?o giao d?ch
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Th?i gian hoàn thành giao d?ch
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// D? li?u b? sung
        /// </summary>
        public Dictionary<string, string> ExtraData { get; set; }
    }
}
