using FITCCRS2.Services.BaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FITCCRS2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDController(IBaseCRUDService<T, TSearch, TInsert, TUpdate> service):base(service)
        {
        }

        [HttpPost]
        public virtual T Insert([FromBody] TInsert insert)
        {
            var result = ((IBaseCRUDService<T, TSearch, TInsert, TUpdate>)this._service).Insert(insert);

            return result;
        }

        [HttpPut("{id}")]
        public virtual T Update(int id, [FromBody] TUpdate update)
        {
            var result = ((IBaseCRUDService<T, TSearch, TInsert, TUpdate>)this._service).Update(id, update);

            return result;
        }

        [HttpDelete("{id}")]
        public virtual T Delete(int id)
        {
            var result = ((IBaseCRUDService<T, TSearch, TInsert, TUpdate>)this._service).Delete(id);

            return result;
        }

    }
}
