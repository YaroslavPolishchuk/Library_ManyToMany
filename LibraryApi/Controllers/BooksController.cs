using Library.DTO.ModelsDTO;
using Library.DTO.ServicesDTO;
using Library.DTO.ServicesViewModel;
using Library.DTO.UnitOfWork;
using Library.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        private readonly IGenericService<BooksDTO, int> serviceBooks;
        private readonly IGenericViewModelService<BookViewModel, int> _serviceVMB;
        private IBookAuthorsUnitOfWorkHandler bookAuthorsUnitOf;        

        public BooksController(IGenericService<BooksDTO, int> serviceBooks, IGenericViewModelService<BookViewModel, int> service, IBookAuthorsUnitOfWorkHandler bookAuthorsUnitOf)
        {
            this.serviceBooks = serviceBooks;
            _serviceVMB = service;
            this.bookAuthorsUnitOf = bookAuthorsUnitOf;           
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                IEnumerable<BooksDTO> collection = serviceBooks.GetAll();
                return (collection != null) ? Request.CreateResponse(HttpStatusCode.OK, collection) :
                    Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                BookViewModel model = _serviceVMB.GetWithChilds(id);
                return (model != null) ? Request.CreateResponse(HttpStatusCode.OK, model) :
                    Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage Create([FromBody]BookViewModel obj)
        {
            try
            {                
                return Request.CreateResponse(HttpStatusCode.OK , bookAuthorsUnitOf.AddBook(obj));                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return (Request.CreateResponse(HttpStatusCode.OK, bookAuthorsUnitOf.RemoveBook(id)));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [HttpPut]
        public HttpResponseMessage Update([FromBody] BookViewModel obj)
        {
            try
            {
                return (Request.CreateResponse(HttpStatusCode.OK, bookAuthorsUnitOf.UpdateBook(obj)));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
