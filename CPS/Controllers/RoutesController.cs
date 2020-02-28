using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPS.Models;

namespace CPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : MastersController
    {

        [HttpPost("AddRoute")]
        public BaseApiResponse<bool> AddRoute(Route data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/AddRoute", () => {
                Db.Route.Add(data);
                Db.SaveChanges();
                return true;
            });
        }


        [HttpPost("AddTpImage")]
        public BaseApiResponse<bool> AddTpImage(Tpimage data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/AddTpImage", () => {
                Db.Tpimage.Add(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpPost("AddTestPoint")]
        public BaseApiResponse<bool> AddTestPoint(TestPoint data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/AddTestPoint", () => {
                data.InspectionDate = DateTime.Now;
                Db.TestPoint.Add(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpPost("EditRoute")]
        public BaseApiResponse<bool> EditRoute(Route data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/EditRoute", () => {
                Db.Route.Update(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpPost("EditTestPoint")]
        public BaseApiResponse<bool> EditTestPoint(TestPoint data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/EditTestPoint", () => {
                Db.TestPoint.Update(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpPost("DeleteRoute")]
        public BaseApiResponse<bool> DeleteRoute(Route data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/DeleteRoute", () => {
                Db.Route.Remove(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpPost("DeleteTpImage")]
        public BaseApiResponse<bool> DeleteTpImage(Tpimage data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/DeleteTpImage", () => {
                Db.Tpimage.Remove(data);
                Db.SaveChanges();
                return true;
            });
        }
        [HttpPost("DeleteTestPoint")]
        public BaseApiResponse<bool> DeleteTestPoint(TestPoint data)
        {
            CPSRequest<bool> request = new CPSRequest<bool>(this,false);
            return request.Execute("Routes/DeleteTestPoint", () => {
                Db.TestPoint.Remove(data);
                Db.SaveChanges();
                return true;
            });
        }

        [HttpGet("GetRoutes")]
        public BaseApiResponse<IEnumerable<Route>> GetRoutes()
        {
            CPSRequest<IEnumerable<Route>> request = new CPSRequest<IEnumerable<Route>>(this,false);
            return request.Execute("Routes/GetRoutes", () => {
                return Db.Route.OrderByDescending(x=>x.Id);
            });
        }

        [HttpGet("GetTestPoints")]
        public BaseApiResponse<IEnumerable<TestPoint>> GetTestPoints(int routeId)
        {
            CPSRequest<IEnumerable<TestPoint>> request = new CPSRequest<IEnumerable<TestPoint>>(this,false);
            return request.Execute("Routes/GetTestPoints", () => {
                return Db.TestPoint.Where(x=>x.RouteId == routeId).OrderByDescending(x=>x.Id);
            });
        }

        [HttpGet("GetExposedPipes")]
        public BaseApiResponse<IEnumerable<ExposedPipe>> GetExposedPipes(int routeId)
        {
            CPSRequest<IEnumerable<ExposedPipe>> request = new CPSRequest<IEnumerable<ExposedPipe>>(this,false);
            return request.Execute("Routes/ExposedPipes", () => {
                return Db.ExposedPipe.Where(x=>x.RouteId == routeId).OrderByDescending(x=>x.Id);
            });
        }

        [HttpGet("GetExposedPipeImages")]
        public BaseApiResponse<IEnumerable<ExposedPipeImage>> GetExposedPipeImages(int exposedPipeId)
        {
            CPSRequest<IEnumerable<ExposedPipeImage>> request = new CPSRequest<IEnumerable<ExposedPipeImage>>(this,false);
            return request.Execute("Routes/ExposedPipeImages", () => {
                return Db.ExposedPipeImage.Where(x=>x.ExposedPipeId == exposedPipeId).OrderByDescending(x=>x.Id);
            });
        }

        [HttpGet("GetTestPointImages")]
        public BaseApiResponse<IEnumerable<Tpimage>> GetTestPointImages(int testPointId)
        {
            CPSRequest<IEnumerable<Tpimage>> request = new CPSRequest<IEnumerable<Tpimage>>(this,false);
            return request.Execute("Routes/GetTestPointImages", () => {
                return Db.Tpimage.Where(x=>x.TestPointId == testPointId).OrderByDescending(x=>x.Id);
            });
        }
    }
}
