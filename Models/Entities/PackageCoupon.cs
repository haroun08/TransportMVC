public class PackageCoupon
{
    public Guid PackageId { get; set; }
    public Package Package { get; set; }

    public Guid CouponId { get; set; }
    public Coupon Coupon { get; set; }
}