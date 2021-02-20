using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MojoCube.Api.UI;
using MojoCube.Web;
using System;
using System.Web.UI.WebControls;
using MojoCube.Web.CurrentExpenses;
using System.Data;
using System.Text;
using System.Collections;
using System.IO;
using System.Web.UI;


namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    /// <summary>
    /// 每新增一個 Method，固定第一個參數為 queryCriteria，假如有資料權限控制，增加第二個參數為 queryDataLimit
    /// </summary>
    public class BASEQ04_SharedQuery
    {
        #region Constructor
        public BASEQ04_SharedQuery()
        {

        }
        #endregion

        #region Property
        #endregion


        public object SearchAllxiangmu(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;
            string str合同类型 = string.Empty;

            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;
                    //case "HETONGLX":
                    //    str合同类型 = wherelimit[1].ToString();
                    //    break;

                }
            }
            string sql = "select * from t_xiangmu1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col8 like '%" + queryCriteria.Trim() + "%' ";
            }
            //if (queryDataLimit.Trim() != "")
            //{
            //    string[] tep = queryDataLimit.Trim().Split(':');
            //    sql += " and col1 like '%" + tep[0] + "%' and col2 = '" + tep[1] + "' ";
            //}
            if (queryDataLimit != "")
            {
                sql += " and col1 = '" + str项目部 + "' and col2 = '" + str项目经理 + "' ";
            }
           
            
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();
           
            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col8"),
                                           col2 = o.Field<string>("col9"),
                                           col3 = o.Field<string>("col10"),
                                           col4 = o.Field<string>("col11"),
                                           col5 = o.Field<string>("col12"),
                                           col6 = o.Field<string>("col31"),
                                           col7 = o.Field<int>("id"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        public object SearchAllxiangmu2(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;

            string[] LimitField = queryDataLimit.Replace(" ", "").Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;

                }
            }
            string sql = "select * from t_xiangmu1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col8 like '%" + queryCriteria.Trim() + "%' ";
            }
            //if (queryDataLimit.Trim() != "")
            //{
            //    string[] tep = queryDataLimit.Trim().Split(':');
            //    sql += " and col1 like '%" + tep[0] + "%' and col2 = '" + tep[1] + "' ";
            //}
            if (queryDataLimit != "")
            {
                sql += " and col6 = '" + str项目部 + "' and col7 = '" + str项目经理 + "' ";
            }

            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col8"),
                                           col2 = o.Field<string>("col9"),
                                           col3 = o.Field<string>("col10"),
                                           col4 = o.Field<string>("col11"),
                                           col5 = o.Field<string>("col12"),
                                           col6 = o.Field<string>("col31"),
                                           col7 = o.Field<int>("id"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //合同名称：Allhetongshi
        public object SearchAllhetongshi(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string str类型 = string.Empty;
            string str用户 = string.Empty;
            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;
            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "LX":
                        str类型 = wherelimit[1].ToString();
                        break;
                    case "YH":
                        str用户 = wherelimit[1].ToString();
                        break;
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;
                }
            }
            string sql0 = "select xiangmu from User_List  where 1 = 1  ";
            if (str用户.Trim() != "")
            {
                sql0 += " and UserName = '" + str用户 + "' ";
            }
           

            string xiangmut = "";
            string strxiangmut = "";
            var queryResult0 = oledbHelper.GetDataTable(sql0);
            if (queryResult0.Rows.Count > 0)
            {
                xiangmut = queryResult0.Rows[0]["xiangmu"].ToString();
            }
            if (xiangmut != "")
            {
                string[] whereField = xiangmut.Trim().Split(',');
                for (int i = 0; i < whereField.Length; i++)
                {
                    if (whereField[i] == "")
                    {
                        continue;
                    }
                    strxiangmut += "'" + whereField[i] + "'" + ",";
                }
                if (strxiangmut.EndsWith(","))
                    strxiangmut = strxiangmut.Substring(0, strxiangmut.Length - 1);
            }

            string sql = string.Empty;

            if (str类型.Trim() != "" && str类型.Trim() == "合作合同")
            {
                sql = "select * from t_hetong2 where 1 = 1  ";
                if (strxiangmut != "")
                {
                    sql += " and col9 in (" + strxiangmut + ")  ";
                }
                if (str项目部.Trim() != "")
                {
                    sql += " and col9 = '" + str项目部 + "'  ";
                }
                if (str项目经理.Trim() != "")
                {
                    sql += "  and col10 = '" + str项目经理 + "' ";
                }

            }
            else
            {
                sql = "select * from t_hetong where 1 = 1  ";
                if (strxiangmut != "")
                {
                    sql += "  and (col8 in (" + strxiangmut + ") or col23 in (" + strxiangmut + ") or col26 in (" + strxiangmut + "))  ";
                }
                if (str项目部.Trim() != "")
                {
                    sql += " and col8 = '" + str项目部 + "'  ";
                }
                if (str项目经理.Trim() != "")
                {
                    sql += "  and col9 = '" + str项目经理 + "' ";
                }

            }
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }

            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                           col3 = o.Field<string>("col3"),
                                           col4 = o.Field<string>("col4"),
                                           col5 = o.Field<string>("col5"),
                                           col6 = o.Field<string>("col6"),
                                           col7 = o.Field<string>("col7"),
                                           col13 = o.Field<string>("col13"),
                                           col8 = o.Field<string>("col8"),
                                           col9 = o.Field<string>("col9"),
                                           col10 = o.Field<string>("col10"),
                                           col23 = o.Field<string>("col23"),
                                           col24 = o.Field<string>("col24"),
                                           col25 = o.Field<string>("col25"),
                                           col26 = o.Field<string>("col26"),
                                           col27 = o.Field<string>("col27"),
                                           col28 = o.Field<string>("col28"),
                                           id = o.Field<int>("id"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //合作单位纳税人：
        public object SearchAllhezuodanwei(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;

            sql = "select * from t_hezuo1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }

            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col11 = o.Field<string>("col11"),
                                           
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //合同名称：
        public object SearchAllhetong(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string str类型 = string.Empty;
            string str用户 = string.Empty;
            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;
            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "LX":
                        str类型 = wherelimit[1].ToString();
                        break;
                    case "YH":
                        str用户 = wherelimit[1].ToString();
                        break;
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;
                }
            }
            string sql0 = "select xiangmu from User_List  where 1 = 1  ";
            if (str用户.Trim() != "")
            {
                sql0 += " and UserName = '" + str用户 + "' ";
            }

            string xiangmut = "";
            string strxiangmut = "";
            var queryResult0 = oledbHelper.GetDataTable(sql0);
            if (queryResult0.Rows.Count > 0)
            {
                xiangmut = queryResult0.Rows[0]["xiangmu"].ToString();
            }
            if (xiangmut != "")
            {
                string[] whereField = xiangmut.Trim().Split(',');
                for (int i = 0; i < whereField.Length; i++)
                {
                    if (whereField[i] == "")
                    {
                        continue;
                    }
                    strxiangmut += "'" + whereField[i] + "'" + ",";
                }
                if (strxiangmut.EndsWith(","))
                    strxiangmut = strxiangmut.Substring(0, strxiangmut.Length - 1);
            }
            string sql = string.Empty;

            if (str类型.Trim() != "" && str类型.Trim() == "合作合同")
            {
                sql = "select * from t_hetong2 where 1 = 1  ";
                if (strxiangmut != "")
                {
                    sql += " and col9 in (" + strxiangmut + ") and col9 = '" + str项目部 + "' ";
                }
                if (str项目部 != "")
                {
                    sql += " and col9 = '" + str项目部 + "' ";
                }
                if (str项目经理 != "")
                {
                    sql += " and col10 = '" + str项目经理 + "' ";
                }
               
            }
            else
            {
                sql = "select * from t_hetong where 1 = 1  ";
                if (strxiangmut != "")
                {
                    sql += " and (col8 in (" + strxiangmut + ") or col23 in (" + strxiangmut + ") or col26 in (" + strxiangmut + "))  ";
                }
                if (str项目部 != "")
                {
                    sql += " and (col8 = '" + str项目部 + "' or col23 = '" + str项目部 + "' or col26 = '" + str项目部 + "' )   ";
                }
                if (str项目经理 != "")
                {
                    sql += " and (col9 = '" + str项目经理 + "' or col24 = '" + str项目经理 + "' or col27 = '" + str项目经理 + "' ) ";
                }
            }
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }

            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                           col3 = o.Field<string>("col3"),
                                           id = o.Field<int>("id"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //合作合同名称：
        public object SearchAllhetong2(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;

            sql = "select * from t_hetong2 where 1 = 1  ";

            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;

            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;

                }
            }
            if (queryDataLimit != "")
            {
                sql += " and col9 = '" + str项目部 + "' and col10 = '" + str项目经理 + "' ";
            }
            //if (queryDataLimit.Trim() != "")
            //{
            //    sql += " and col9 = '" + queryDataLimit.Trim() + "' ";
            //}
           
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }

            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                           col3 = o.Field<string>("col3"),
                                           col4 = o.Field<string>("col4"),
                                           col5 = o.Field<string>("col5"),
                                           col6 = o.Field<string>("col6"),
                                           col7 = o.Field<string>("col7"),
                                           col8 = o.Field<string>("col8"),
                                           col9 = o.Field<string>("col9"),
                                           col10 = o.Field<string>("col10"),
                                           col11 = o.Field<string>("col11"),
                                           col12 = o.Field<string>("col12"),
                                           id = o.Field<int>("id"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //跨区域经营地址：
        public object SearchAlladdress(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col12,col5,col3,col4 from t_caiwu1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col5 like '%" + queryCriteria.Trim() + "%' ";
            }
            if (queryDataLimit.Trim() != "")
            {
                sql += " and col7 = '" + queryDataLimit.Trim() + "' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col12"),
                                           col2 = o.Field<string>("col5"),
                                           col3 = o.Field<string>("col3"),
                                           col4 = o.Field<string>("col4"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //跨区域涉税事项报验管理编号：
        public object SearchAllbianhao(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col12,col5,col3,col4 from t_caiwu1 where 1 = 1 ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col12 like '%" + queryCriteria.Trim() + "%' ";
            }
            if (queryDataLimit.Trim() != "")
            {
                sql += " and col7 = '" + queryDataLimit.Trim() + "' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col12"),
                                           col2 = o.Field<string>("col5"),
                                           col3 = o.Field<string>("col3"),
                                           col4 = o.Field<string>("col4"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //付款单位名称：
        public object SearchAllfukuanname(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "";
            if (queryDataLimit.Trim() != "" && queryDataLimit.Trim() == "合作合同")
            {
                sql = "select * from t_hezuo1 where 1 = 1  ";

            }
            else
            {
                sql = "select col1,col8 as col11,col9 as col12,col10 as col13,col11 as col14,col12 as col15 from t_keshang where 1 = 1  ";

            }
           
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col11"),
                                           col3 = o.Field<string>("col12"),
                                           col4 = o.Field<string>("col13"),
                                           col5 = o.Field<string>("col14"),
                                           col6 = o.Field<string>("col15"),
                                          
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //开票单位名称：
        public object SearchAllkaipiaoname(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            
            string sql = "select * from t_hezuo1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col11"),
                                           col3 = o.Field<string>("col12"),
                                           col4 = o.Field<string>("col13"),
                                           col5 = o.Field<string>("col14"),
                                           col6 = o.Field<string>("col15"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //客商管理单位：
        public object Searchdanwei1(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col1 from t_keshang where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //施工管理单位：合作单位管理
        public object Searchdanwei2(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col1 from t_hezuo1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //施工管理单位：合作单位管理
        public object Searchdanwei22(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col1 from t_hezuo1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //
        public object SearchAllhetongxiangduifang(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "select col1,col11 as col8 from t_hezuo1 union select col1, col8 from t_keshang  where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql = "select col1,col11 as col8 from t_hezuo1 where 1 = 1 and col1 like '%" + queryCriteria.Trim() + "%'  union select col1, col8 from t_keshang  where 1 = 1 and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col8 = o.Field<string>("col8"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //shigong
        public object SearchAllshigong(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string str项目部 = string.Empty;
            string str项目经理 = string.Empty;
       
            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "XMB":
                        str项目部 = wherelimit[1].ToString();
                        break;
                    case "XMJL":
                        str项目经理 = wherelimit[1].ToString();
                        break;
                    
                }
            }

            string sql = "select * from t_hezuo3  where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col3 like '%" + queryCriteria.Trim() + "%' ";
            }
            if (queryDataLimit != "")
            {
                sql += " and col1 = '" + str项目部 + "' and col2 = '" + str项目经理 + "' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                           col3 = o.Field<string>("col3"),
                                           id = o.Field<int>("id"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //hezuo2
        public object SearchAllhezuo2(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string sql0 = "select xiangmu from User_List  where 1 = 1  ";
            //if (queryDataLimit.Trim() != "")
            //{
            //    sql0 += " and UserName = '" + queryDataLimit.Trim() + "' ";
            //}

            //string xiangmut = "";
            //string strxiangmut = "";
            //var queryResult0 = oledbHelper.GetDataTable(sql0);
            //if (queryResult0.Rows.Count > 0)
            //{
            //    xiangmut = queryResult0.Rows[0]["xiangmu"].ToString();
            //}
            //if (xiangmut != "")
            //{
            //    string[] whereField = xiangmut.Trim().Split(',');
            //    for (int i = 0; i < whereField.Length; i++)
            //    {
            //        if (whereField[i] == "")
            //        {
            //            continue;
            //        }
            //        strxiangmut += "'" + whereField[i] + "'" + ",";
            //    }
            //    if (strxiangmut.EndsWith(","))
            //        strxiangmut = strxiangmut.Substring(0, strxiangmut.Length - 1);
            //}

            string sql = "select * from t_hezuo2  where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            }
            if (queryDataLimit != "")
            {
                sql += " and col8 = '" + queryDataLimit + "' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                           col3 = o.Field<string>("col3"),
                                           col11 = o.Field<string>("col11"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //caiwu22
        public object SearchAllcaiwu22(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string strNAME = string.Empty;
            string strNO = string.Empty;
            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "HTNAME":
                        strNAME = wherelimit[1].ToString();
                        break;
                    case "HTNO":
                        strNO = wherelimit[1].ToString();
                        break;
                }
            }
            string sql = "select * from t_xiangmu1  where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col8 like '%" + queryCriteria.Trim() + "%' ";
            }
            if (queryDataLimit.Trim() != "")
            {
                sql += " and col1 = '" + strNAME + "' and col2 = '" + strNO + "' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col8"),
                                           col2 = o.Field<string>("col9"),
                                           id = o.Field<int>("id"),
                                           col3 = getS(o.Field<int>("id").ToString()).开票金额,
                                           col4 = getS(o.Field<int>("id").ToString()).到账金额,
                                           
                                           
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        public class AAmonut
        {
            public string 开票金额 { get; set; }
            public string 到账金额 { get; set; }
        }
        AAmonut getS(string strid)
        {
            AAmonut AAmonut = new AAmonut();
            string fapiaono = string.Empty;
            decimal 总计到账金额 = 0;
            decimal 总计开票金额 = 0;
            string 开票金额 = "0";
            string 开票日期 = "";
            DataSet ds = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + strid + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int ii = 0; ii < ds.Tables[0].Rows.Count; ii++)
                {

                    fapiaono = ds.Tables[0].Rows[ii]["col18"].ToString();
                    DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' ");
                    if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        开票金额 = ds.Tables[0].Rows[ii]["col22"].ToString();
                        if (开票金额 == "" || 开票金额 == "&nbsp;")
                        {
                            开票金额 = "0";
                        }
                        总计开票金额 += Convert.ToDecimal(开票金额);

                        DataSet ds1 = Sql.SqlQueryDS("select * from t_caiwu51 where col1 = '" + fapiaono + "' and col9 ='1' and col3= '" + ds.Tables[0].Rows[ii]["col8"].ToString() + "' and col4= '" + ds.Tables[0].Rows[ii]["col9"].ToString() + "' order by col2  ");
                        if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int kkk = 0; kkk < ds1.Tables[0].Rows.Count; kkk++)
                            {
                                string 到账金额 = ds1.Tables[0].Rows[kkk]["col6"].ToString();
                                if (到账金额 == "" || 到账金额 == "&nbsp;")
                                {
                                    到账金额 = "0";
                                }
                                总计到账金额 += Convert.ToDecimal(到账金额);
                            }
                        }

                        开票日期 = ds2.Tables[0].Rows[0]["col32"].ToString();

                    }
                }

            }
            AAmonut.开票金额= 总计开票金额.ToString();
            AAmonut.到账金额 = 总计到账金额.ToString();
            return AAmonut;
        }

        //hezuo1
        public object SearchAllhezuo1(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            string sql = "select * from t_hezuo1 where 1 = 1  ";
            if (queryCriteria.Trim() != "")
            {
                sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            } 
           
           
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col8"),
                                           col3 = o.Field<string>("col14"),
                                           col4 = o.Field<string>("col15"),
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //Alljine
        public object SearchAlljine(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();

            DataTable dt = new DataTable();
            dt.Columns.Add("A1");
            dt.Columns.Add("A11");
            dt.Columns.Add("A2");
            dt.Columns.Add("A3");
            dt.Columns.Add("A4");
            dt.Columns.Add("A5");
            dt.Columns.Add("A6");
            dt.Columns.Add("A7");
            dt.Columns.Add("A8");
            dt.Columns.Add("A9");
            dt.Columns.Add("A10");
            DataRow dr;
            string fapiaono = string.Empty;
            int iiii = 0;
            Boolean youshuju = false;
            
            if (queryDataLimit == "")
            {
                queryDataLimit = "0";
            }

            DataSet ds02 = Sql.SqlQueryDS("select * from t_caiwu22 where col43 = '" + queryDataLimit + "' and (col49 <> '合作合同' or col49 = '' or col49 is null) ");
            if (ds02 != null && ds02.Tables[0] != null && ds02.Tables[0].Rows.Count > 0)
            {
                for (int ii = 0; ii < ds02.Tables[0].Rows.Count; ii++)
                {
                    fapiaono = ds02.Tables[0].Rows[ii]["col18"].ToString();
                    DataSet ds2 = Sql.SqlQueryDS("select * from t_caiwu2 where col53 = '" + fapiaono + "' and col55 like '%确定开票%' and col33 not like '%发票作废%' ");
                    if (ds2 != null && ds2.Tables[0] != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        youshuju = false;
                        for (int kk = 0; kk < ds2.Tables[0].Rows.Count; kk++)
                        {
                            if (youshuju == true)
                            {
                                iiii++;
                            }

                            youshuju = true;
                            
                            dr = dt.NewRow();
                            dr["A1"] = iiii + 1;
                            dr["A11"] = fapiaono;
                            dr["A2"] = ds02.Tables[0].Rows[ii]["col22"];
                            dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                            dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                            dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                            dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];

                            dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                            dr["A8"] = ds2.Tables[0].Rows[kk]["col39"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col39"].ToString();
                            dr["A9"] = ds2.Tables[0].Rows[kk]["col40"];
                            dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                            dt.Rows.Add(dr);
                            //if (ds2.Tables[0].Rows[kk]["col39"].ToString() != "")
                            //{


                            //    dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                            //    dr["A8"] = ds2.Tables[0].Rows[kk]["col39"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col39"].ToString();
                            //    dr["A9"] = ds2.Tables[0].Rows[kk]["col40"];
                            //    dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                            //    dt.Rows.Add(dr);
                            //}
                            //else
                            //{
                            //    dr["A7"] = "";
                            //    dr["A8"] = "";
                            //    dr["A9"] = "";
                            //    dr["A10"] = "";
                            //    dt.Rows.Add(dr);
                            //}
                            //dt.Rows.Add(dr);

                            youshuju = true;

                            if (ds2.Tables[0].Rows[kk]["col41"].ToString() != "")
                            {
                                dr = dt.NewRow();
                                dr["A1"] = iiii + 1;
                                dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                dr["A2"] = ds02.Tables[0].Rows[ii]["col22"];
                                dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                dr["A8"] = ds2.Tables[0].Rows[kk]["col41"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col41"].ToString();
                                dr["A9"] = ds2.Tables[0].Rows[kk]["col42"];
                                dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                dt.Rows.Add(dr);
                            }


                            youshuju = true;

                            if (ds2.Tables[0].Rows[kk]["col43"].ToString() != "")
                            {
                                dr = dt.NewRow();
                                dr["A1"] = iiii + 1;
                                dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                dr["A2"] = ds02.Tables[0].Rows[ii]["col22"];
                                dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                dr["A8"] = ds2.Tables[0].Rows[kk]["col43"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col43"].ToString();
                                dr["A9"] = ds2.Tables[0].Rows[kk]["col44"];
                                dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                dt.Rows.Add(dr);
                            }


                            youshuju = true;

                            if (ds2.Tables[0].Rows[kk]["col45"].ToString() != "")
                            {
                                dr = dt.NewRow();
                                dr["A1"] = iiii + 1;
                                dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                dr["A2"] = ds02.Tables[0].Rows[ii]["col22"];
                                dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                dr["A8"] = ds2.Tables[0].Rows[kk]["col45"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col45"].ToString();
                                dr["A9"] = ds2.Tables[0].Rows[kk]["col46"];
                                dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                dt.Rows.Add(dr);
                            }


                            youshuju = true;

                            if (ds2.Tables[0].Rows[kk]["col47"].ToString() != "")
                            {
                                dr = dt.NewRow();
                                dr["A1"] = iiii + 1;
                                dr["A11"] = ds02.Tables[0].Rows[ii]["col18"];
                                dr["A2"] = ds02.Tables[0].Rows[ii]["col22"];
                                dr["A3"] = ds02.Tables[0].Rows[ii]["col23"];
                                dr["A4"] = ds02.Tables[0].Rows[ii]["col39"];
                                dr["A5"] = ds02.Tables[0].Rows[ii]["col40"];
                                dr["A6"] = ds02.Tables[0].Rows[ii]["col29"];
                                dr["A7"] = ds2.Tables[0].Rows[kk]["col32"];
                                dr["A8"] = ds2.Tables[0].Rows[kk]["col47"].ToString() == "" ? "" : ds2.Tables[0].Rows[kk]["col47"].ToString();
                                dr["A9"] = ds2.Tables[0].Rows[kk]["col48"];
                                dr["A10"] = ds2.Tables[0].Rows[kk]["col49"];
                                dt.Rows.Add(dr);
                            }


                        }
                    }
                }

            }

            //string strNAME = string.Empty;
            //string strNO = string.Empty;
            //string[] LimitField = queryDataLimit.Replace(" ", "").Trim(',').Split(',');
            //for (int i = 0; i < LimitField.Length; i++)
            //{
            //    string[] wherelimit = LimitField[i].Split(':');
            //    switch (wherelimit[0].Trim().ToUpper())
            //    {
            //        case "HTNAME":
            //            strNAME = wherelimit[1].ToString();
            //            break;
            //        case "HTNO":
            //            strNO = wherelimit[1].ToString();
            //            break;
            //    }
            //}
            //string sql = "select * from t_caiwu22  where 1 = 1  ";
            //if (queryCriteria.Trim() != "")
            //{
            //    sql += " and col1 like '%" + queryCriteria.Trim() + "%' ";
            //}
            //if (queryDataLimit.Trim() != "")
            //{
            //    sql += " and col1 = '" + strNAME + "' and col2 = '" + strNO + "' ";
            //}
            //var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (dt.Rows.Count > 0)
            {
                var objList_revised = (from o in dt.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("A11"),
                                           col2 = o.Field<string>("A2"),
                                           col3 = o.Field<string>("A3"),
                                           col4 = o.Field<string>("A4"),
                                           col5 = o.Field<string>("A5"),
                                           col6 = o.Field<string>("A6"),
                                           col7 = o.Field<string>("A7"),
                                           col8 = o.Field<string>("A8"),
                                           col9 = o.Field<string>("A9"),
                                          
                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //根据结算管理中选择：
        public object SearchAlljiesuan(string queryCriteria, string queryDataLimit)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = "";
            sql = "select * from t_caiwu5 where 1 = 1  ";

            string str1 = string.Empty;
            string str2 = string.Empty;
            string[] LimitField = queryDataLimit.Trim(',').Split(',');
            for (int i = 0; i < LimitField.Length; i++)
            {
                string[] wherelimit = LimitField[i].Split(':');
                switch (wherelimit[0].Trim().ToUpper())
                {
                    case "TT1":
                        str1 = wherelimit[1].ToString();
                        break;
                    case "TT2":
                        str2 = wherelimit[1].ToString();
                        break;
                    //case "HETONGLX":
                    //    str合同类型 = wherelimit[1].ToString();
                    //    break;

                }
            }

            if (str1.Trim() != "" && str2.Trim() != "")
            {
                sql += " and col3 like '%" + str1.Trim() + "%' and  col4 like '%" + str2.Trim() + "%' ";
            }
            if (queryCriteria.Trim() != "")
            {
                sql += " and col22 like '%" + queryCriteria.Trim() + "%' ";
            }
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col22"),
                                           col2 = o.Field<string>("col23"),
                                           col3 = o.Field<string>("col24"),
                                           col4 = o.Field<string>("col25"),
                                           col5 = o.Field<string>("col26"),
                                           col6 = o.Field<string>("col27"),
                                           col7 = o.Field<string>("col28"),
                                           col8 = o.Field<string>("col46"),
                                           col9 = o.Field<string>("col45"),

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }


        //查询所有审核人员：
        public object SearchAllshenherenyuan(string queryDataLimit, string queryCriteria)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,col1  from t_shenhe3 where 1=1     ";
            if (queryCriteria == "0")
            {
                sql += "and col1 = '1' ";
            }
            if (queryCriteria == "1")
            {
                sql += "and col1 = '2' ";
            }
            else if (queryCriteria == "2")
            {
                sql += "and col1 = '3' ";
            }
            else if (queryCriteria == "3")
            {
                sql += "and col1 = '4' ";
            }
            else if (queryCriteria == "4")
            {
                sql += "and col1 = '5' ";
            }
            else if (queryCriteria == "5")
            {
                sql += "and col1 = '6' ";
            }

            if (queryDataLimit.Trim() != "")
            {
                sql += " and col2 like '%" + queryDataLimit.Trim() + "%' ";
            }

            dataSource = oledbHelper.GetDataTable(sql);


           
            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),
                                          

                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }

        //查询所有审核人员：
        public object SearchAllshenherenyuan2(string queryDataLimit, string queryCriteria)
        {
            OledbHelper oledbHelper = new OledbHelper();
            string sql = string.Empty;
            DataTable dataSource = new DataTable();
            sql = "select col2,col1  from t_shenhe2 where 1=1     ";
            if (queryCriteria == "0")
            {
                sql += "and col1 = '1' ";
            }
            if (queryCriteria == "1")
            {
                sql += "and col1 = '2' ";
            }
            else if (queryCriteria == "2")
            {
                sql += "and col1 = '3' ";
            }
            else if (queryCriteria == "3")
            {
                sql += "and col1 = '4' ";
            }
            else if (queryCriteria == "4")
            {
                sql += "and col1 = '5' ";
            }
            else if (queryCriteria == "5")
            {
                sql += "and col1 = '6' ";
            }

            if (queryDataLimit.Trim() != "")
            {
                sql += " and col2 like '%" + queryDataLimit.Trim() + "%' ";
            }

            dataSource = oledbHelper.GetDataTable(sql);



            var queryResult = oledbHelper.GetDataTable(sql);
            var result = new object();

            if (queryResult.Rows.Count > 0)
            {
                var objList_revised = (from o in queryResult.AsEnumerable()
                                       select new
                                       {
                                           col1 = o.Field<string>("col1"),
                                           col2 = o.Field<string>("col2"),


                                       }).OrderBy(o => o.col1).ToList();

                result = objList_revised;
            }

            return result;
        }




    }

}