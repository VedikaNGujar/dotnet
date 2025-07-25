﻿using Mango.Web.Helper;
using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = cartDto,
                URL = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = cartDto,
                URL =  SD.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsnyc(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.GET,
                URL =  SD.ShoppingCartAPIBase + "/api/cart/GetCart/"+ userId
            });
        }

        
        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = cartDetailsId,
                URL =  SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

      
        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.HttpMethodType.POST,
                Data = cartDto,
                URL =  SD.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
