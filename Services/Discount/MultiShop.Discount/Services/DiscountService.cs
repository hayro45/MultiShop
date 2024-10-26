using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
            
            var parameters = new DynamicParameters();

            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        { 
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);
            using (var conneciton = _context.CreateConnection())
            {
                var values = await conneciton.QueryFirstOrDefaultAsync<GetDiscountCouponByIdDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponId", updateCouponDto.CouponId);

            using (var conneciton = _context.CreateConnection())
            {
                await conneciton.ExecuteAsync(query, parameters);
            }
        }
    }
}
