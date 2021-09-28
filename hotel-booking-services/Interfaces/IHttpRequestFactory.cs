﻿using hotel_booking_model.commons;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IHttpRequestFactory
    {
        /// <summary>
        /// Makes a HttpDelete request to the api with baseURl
        /// to delete an entity of type TRes from the database
        /// name-identifiers should be passed as query parameter in url
        /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="url"></param>
        /// <param name="baseUrl"></param>
        /// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
        Task<BasicResponse<TRes>> DeleteRequestAsync<TRes>(string url, string baseUrl = null) where TRes : class;

        /// <summary>
        /// Makes a HttpGet request to the api with baseUrl to 
        /// to search for the eneity of type TRes swith name-identifier
        /// which is passed in the url
        /// a TRes object         /// </summary>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="url"></param>
        /// <param name="baseUrl"></param>
        /// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
        Task<BasicResponse<TRes>> GetRequestAsync<TRes>(string url, string baseUrl = null) where TRes : BasicResponse<TRes>;

        /// <summary>
        /// Makes a HttpPost request to the api with baseUrl 
        /// with a TReq entity while expecting a TRes entity back from the api
        /// TReq -Request value(s) sending to the api
        /// TRes -Expected value(s) form api
        /// </summary>
        /// <typeparam name="TReq"></typeparam>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="baseUrl"></param>
        /// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
        Task<BasicResponse<TRes>> PostRequestAsync<TReq, TRes>(string url, TReq content, string baseUrl = null)
            where TReq : class
            where TRes : class;

        /// <summary>
        /// Makes a HttpPost to the api with baseUrl
        /// Send a file of the IFormFile format to the api
        /// which will give back a uri
        /// </summary>
        /// <typeparam name="TReq"></typeparam>
        /// <typeparam name="TRes"></typeparam>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="baseUrl"></param>
        /// <returns>A BasicResponse<TRes> object that has a success field thats is ture if only the request succeded</returns>
        Task<BasicResponse<TRes>> UploadFileAsync<TReq, TRes>(string url, TReq file, string baseUrl = null)
            where TReq : IFormFile
            where TRes : class;
    }
}