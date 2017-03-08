using meiko.Models;
using MeikoAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeikoAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            try
            {
                using (var db = new MeikoContext())
                {
                    return Ok(db.仕入実績月部門別集計ビューs.ToList());
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/values
        public IHttpActionResult GetPeriod(DateTime 対象開始, DateTime 対象終了)
        {
            try
            {
                using (var db = new MeikoContext())
                {
                    var data = (from a in db.仕入実績ビューs
                                where a.売上日 >= 対象開始
                                && a.売上日 <= 対象終了
                                group a by new { a.部門 } into g
                                select new 仕入実績集計結果
                                {
                                    部門 = g.Max(s => s.部門),
                                    数量 = g.Sum(s => s.数量),
                                    金額 = g.Sum(s => s.金額),
                                    粗利 = g.Sum(s => s.粗利)
                                }).ToList();

                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}