using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CopyMFRubikCubePowerContent.Admin.xiangmu
{
    public class CommonQuery_BLL
    {
        #region Constructor
        public CommonQuery_BLL()
        {
            this.ColumnText = new Dictionary<int, string>();
            this.ColumnVisible = new Dictionary<int, bool>();
            this.PropertyName = new Dictionary<int, string>();
        }
        #endregion

        #region Field
        public string jsTemplate = @"<script>
                                        if(window.opener)
                                        {
                                            var functionObj = typeof (window.opener.GetValueFromWindowOpen);

                                            if (functionObj === 'function' || functionObj === 'object') {

                                                var obj = {};
                                                #snippet

                                                window.opener.GetValueFromWindowOpen(obj);
                                            };
                                        }
                                    </script>
                                    ";
        #endregion

        #region Property
        public string Purpose { get; set; }
        public string Identity { get; set; }
        public string Title { get; set; }
        public string Criteria { get; set; }
        public string CriteriaToolTip { get; set; }
        public string QueryMethodName { get; set; }
        public string jsScript { get; set; }
        public Dictionary<int, string> ColumnText { get; set; }
        public Dictionary<int, bool> ColumnVisible { get; set; }
        public Dictionary<int, string> PropertyName { get; set; }
        #endregion

        #region Method

        /// <summary>
        /// 根據傳入的 GridViewRow 去產生 javascript 語法
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetJSscript(GridViewRow row)
        {
            var sourceRow = row;
            var rowValue = "";

            var initialString = @"obj.purpose ='" + this.Purpose + @"';"
                + @"obj.identity ='" + this.Identity + @"';";

            StringBuilder sb = new StringBuilder(initialString);

            if (row.Cells.Count > 0)
            {
                // 组字串
                foreach (var o in this.PropertyName)
                {
                    rowValue = HttpUtility.HtmlDecode(sourceRow.Cells[o.Key].Text);
                    sb.Append("obj." + o.Value + @" ='" + rowValue + @"';");
                }
            }

            var jsScript = this.jsTemplate.Replace(@"#snippet", sb.ToString());

            return jsScript;
        }

        public void SetProfileProperty(string queryPurpose, string queryIdentity)
        {
            this.Purpose = queryPurpose;
            this.Identity = queryIdentity;

            switch (queryPurpose)
            {
                #region Allxiangmu

                case "Allxiangmu":

                    // 基本外觀
                    this.Title = "项目名称检索画面";
                    this.Criteria = "项目名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllxiangmu";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "项目名称");
                    this.ColumnText.Add(2, "项目编码");
                    this.ColumnText.Add(3, "单项工程名称");
                    this.ColumnText.Add(4, "结算金额");
                    this.ColumnText.Add(5, "审定金额");
                    this.ColumnText.Add(6, "结算类型");
                    this.ColumnText.Add(7, "id");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, false);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, false);
                    this.ColumnVisible.Add(6, true);
                    this.ColumnVisible.Add(7, false);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                    this.PropertyName.Add(7, "col7");

                    break;

                #endregion

                #region Allxiangmu2

                case "Allxiangmu2":

                    // 基本外觀
                    this.Title = "项目名称检索画面";
                    this.Criteria = "项目名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllxiangmu2";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "项目名称");
                    this.ColumnText.Add(2, "项目编码");
                    this.ColumnText.Add(3, "单项工程名称");
                    this.ColumnText.Add(4, "结算金额");
                    this.ColumnText.Add(5, "审定金额");
                    this.ColumnText.Add(6, "结算类型");
                    this.ColumnText.Add(7, "id");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, false);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, false);
                    this.ColumnVisible.Add(6, false);
                    this.ColumnVisible.Add(7, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                    this.PropertyName.Add(7, "col7");

                    break;

                #endregion

                #region Allhetong

                case "Allhetong":

                    // 基本外觀
                    this.Title = "合同名称检索画面";
                    this.Criteria = "合同名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhetong";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "合同名称");
                    this.ColumnText.Add(2, "合同编号");
                    this.ColumnText.Add(3, "合同金额");
                    this.ColumnText.Add(4, "id");
                    
                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, false);
                   
                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "id");
                    
                    break;

                #endregion

                #region Allhetongshi

                case "Allhetongshi":

                    // 基本外觀
                    this.Title = "合同名称检索画面";
                    this.Criteria = "合同名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhetongshi";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "合同名称");
                    this.ColumnText.Add(2, "合同编号");
                    this.ColumnText.Add(3, "合同金额");
                    this.ColumnText.Add(4, "合同名称4");
                    this.ColumnText.Add(5, "合同编号5");
                    this.ColumnText.Add(6, "合同金额6");
                    this.ColumnText.Add(7, "合同名称7");
                    this.ColumnText.Add(8, "合同编号8");
                    this.ColumnText.Add(9, "合同金额9");
                    this.ColumnText.Add(10, "合同名称10");
                    this.ColumnText.Add(11, "合同编号11");
                    this.ColumnText.Add(12, "合同名称12");
                    this.ColumnText.Add(13, "合同编号13");
                    this.ColumnText.Add(14, "合同名称14");
                    this.ColumnText.Add(15, "合同编号15");
                    this.ColumnText.Add(16, "合同名称16");
                    this.ColumnText.Add(17, "合同编号17");
                    this.ColumnText.Add(18, "id");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, false);
                    this.ColumnVisible.Add(5, false);
                    this.ColumnVisible.Add(6, false);
                    this.ColumnVisible.Add(7, false);
                    this.ColumnVisible.Add(8, false);
                    this.ColumnVisible.Add(9, false);
                    this.ColumnVisible.Add(10, false);
                    this.ColumnVisible.Add(11, false);
                    this.ColumnVisible.Add(12, false);
                    this.ColumnVisible.Add(13, false);
                    this.ColumnVisible.Add(14, false);
                    this.ColumnVisible.Add(15, false);
                    this.ColumnVisible.Add(16, false);
                    this.ColumnVisible.Add(17, false);
                    this.ColumnVisible.Add(18, false);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                    this.PropertyName.Add(7, "col7");
                    this.PropertyName.Add(8, "col13");
                    this.PropertyName.Add(9, "col8");
                    this.PropertyName.Add(10, "col9");
                    this.PropertyName.Add(11, "col10");
                    this.PropertyName.Add(12, "col23");
                    this.PropertyName.Add(13, "col24");
                    this.PropertyName.Add(14, "col25");
                    this.PropertyName.Add(15, "col26");
                    this.PropertyName.Add(16, "col27");
                    this.PropertyName.Add(17, "col28");
                    this.PropertyName.Add(18, "id");

                    break;

                #endregion

                #region Allhezuodanwei

                case "Allhezuodanwei":

                    // 基本外觀
                    this.Title = "合作单位检索画面";
                    this.Criteria = "纳税人名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhezuodanwei";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "纳税人名称");
                    this.ColumnText.Add(2, "纳税人识别号");
                    
                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                   
                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    
                    break;

                #endregion

                #region Allhetong2

                case "Allhetong2":

                    // 基本外觀
                    this.Title = "合同名称检索画面";
                    this.Criteria = "合同名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhetong2";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "总包合同名称");
                    this.ColumnText.Add(2, "总包合同编号");
                    this.ColumnText.Add(3, "总包合同金额");
                    this.ColumnText.Add(4, "建设单位名称");
                    this.ColumnText.Add(5, "施工单位名称");
                    this.ColumnText.Add(6, "分包单位名称");
                    this.ColumnText.Add(7, "分包合同金额");
                    this.ColumnText.Add(8, "分包合同结算依据");
                    this.ColumnText.Add(9, "劳务单位名称");
                    this.ColumnText.Add(10, "劳务合同金额");
                    this.ColumnText.Add(11, "劳务合同名称");
                    this.ColumnText.Add(12, "劳务合同结算依据");
                    this.ColumnText.Add(13, "id");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, false);
                    this.ColumnVisible.Add(5, false);
                    this.ColumnVisible.Add(6, false);
                    this.ColumnVisible.Add(7, false);
                    this.ColumnVisible.Add(8, false);
                    this.ColumnVisible.Add(9, false);
                    this.ColumnVisible.Add(10, false);
                    this.ColumnVisible.Add(11, false);
                    this.ColumnVisible.Add(12, false);
                    this.ColumnVisible.Add(13, false);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                    this.PropertyName.Add(7, "col7");
                    this.PropertyName.Add(8, "col8");
                    this.PropertyName.Add(9, "col9");
                    this.PropertyName.Add(10, "col10");
                    this.PropertyName.Add(11, "col11");
                    this.PropertyName.Add(12, "col12");
                    this.PropertyName.Add(13, "id");

                    break;

                #endregion

                #region Alladdress

                case "Alladdress":

                    // 基本外觀
                    this.Title = "跨区域经营地址检索画面";
                    this.Criteria = "跨区域经营地址";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAlladdress";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "跨区域涉税事项报验管理编号");
                    this.ColumnText.Add(2, "跨区域经营地址");
                    this.ColumnText.Add(3, "纳税人名称");
                    this.ColumnText.Add(4, "纳税人识别号");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                   
                    break;

                #endregion

                #region Allbianhao

                case "Allbianhao":

                    // 基本外觀
                    this.Title = "跨区域涉税事项报验管理编号检索画面";
                    this.Criteria = "跨区域涉税事项报验管理编号";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllbianhao";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "跨区域涉税事项报验管理编号");
                    this.ColumnText.Add(2, "跨区域经营地址");
                    this.ColumnText.Add(3, "纳税人名称");
                    this.ColumnText.Add(4, "纳税人识别号");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    
                    break;

                #endregion

                #region Allfukuanname

                case "Allfukuanname":

                    // 基本外觀
                    this.Title = "付款单位名称检索画面";
                    this.Criteria = "付款单位名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllfukuanname";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "付款单位名称");
                    this.ColumnText.Add(2, "付款单位纳税人识别号");
                    this.ColumnText.Add(3, "付款单位地址");
                    this.ColumnText.Add(4, "付款单位电话");
                    this.ColumnText.Add(5, "付款单位开户行");
                    this.ColumnText.Add(6, "付款单位账号");
                   
                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, true);
                    this.ColumnVisible.Add(6, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");

                    break;

                #endregion

                #region Allkaipiaoname

                case "Allkaipiaoname":

                    // 基本外觀
                    this.Title = "开票单位名称检索画面";
                    this.Criteria = "开票单位名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllkaipiaoname";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "开票单位名称");
                    this.ColumnText.Add(2, "开票单位纳税人识别号");
                    this.ColumnText.Add(3, "开票单位地址");
                    this.ColumnText.Add(4, "开票单位电话");
                    this.ColumnText.Add(5, "开票单位开户行");
                    this.ColumnText.Add(6, "开票单位账号");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, true);
                    this.ColumnVisible.Add(6, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");

                    break;

                #endregion

                #region Alldanwei1

                case "Alldanwei1":

                    // 基本外觀
                    this.Title = "建设单位检索画面";
                    this.Criteria = "建设单位";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "Searchdanwei1";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "建设单位");
                   
                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                   
                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                   
                    break;

                #endregion

                #region Alldanwei2

                case "Alldanwei2":

                    // 基本外觀
                    this.Title = "建设单位检索画面";
                    this.Criteria = "建设单位";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "Searchdanwei2";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "建设单位");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");

                    break;

                #endregion

                #region Alldanwei22

                case "Alldanwei22":

                    // 基本外觀
                    this.Title = "建设单位检索画面";
                    this.Criteria = "建设单位";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "Searchdanwei22";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "建设单位");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");

                    break;

                #endregion

                #region Allhetongxiangduifang

                case "Allhetongxiangduifang":

                    // 基本外觀
                    this.Title = "合同相对方名称检索画面";
                    this.Criteria = "合同相对方名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhetongxiangduifang";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "合同相对方名称");
                    this.ColumnText.Add(2, "纳税人识别号");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col8");

                    break;

                #endregion

                #region Allshigong

                case "Allshigong":

                    // 基本外觀
                    this.Title = "施工队结算人员检索画面";
                    this.Criteria = "施工队结算人员";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllshigong";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "项目部");
                    this.ColumnText.Add(2, "项目经理");
                    this.ColumnText.Add(3, "施工队长姓名");
                    this.ColumnText.Add(4, "id");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, false);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "id");

                    break;

                #endregion

                #region Allhezuo2

                case "Allhezuo2":

                    // 基本外觀
                    this.Title = "施工队长检索画面";
                    this.Criteria = "施工队长";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhezuo2";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "施工队长姓名");
                    this.ColumnText.Add(2, "施工队长电话");
                    this.ColumnText.Add(3, "施工队长身份证号");
                    this.ColumnText.Add(4, "施工能力");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col11");

                    break;

                #endregion

                #region Allcaiwu22

                case "Allcaiwu22":

                    // 基本外觀
                    this.Title = "收款管理项目检索画面";
                    this.Criteria = "收款管理项目";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllcaiwu22";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "项目名称");
                    this.ColumnText.Add(2, "项目编码");
                    this.ColumnText.Add(3, "id");
                    this.ColumnText.Add(4, "开票金额");
                    this.ColumnText.Add(5, "到账金额");
                    
                   
                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, false);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, true);
                   
                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "id");
                    this.PropertyName.Add(4, "col3");
                    this.PropertyName.Add(5, "col4");
                   
                    break;

                #endregion

                #region Alljine

                case "Alljine":

                    // 基本外觀
                    this.Title = "总包发票金额检索画面";
                    this.Criteria = "总包发票金额";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAlljine";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "发票申请单号");
                    this.ColumnText.Add(2, "开票金额");
                    this.ColumnText.Add(3, "货物、服务名称");
                    this.ColumnText.Add(4, "发票类型");
                    this.ColumnText.Add(5, "发票类别");
                    this.ColumnText.Add(6, "税率");
                    this.ColumnText.Add(7, "开票日期");
                    this.ColumnText.Add(8, "到账金额");
                    this.ColumnText.Add(9, "到账日期");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                     this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);
                     this.ColumnVisible.Add(5, true);
                    this.ColumnVisible.Add(6, true);
                     this.ColumnVisible.Add(7, true);
                    this.ColumnVisible.Add(8, true);
                    this.ColumnVisible.Add(9, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                     this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                     this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                     this.PropertyName.Add(7, "col7");
                    this.PropertyName.Add(8, "col8");
                    this.PropertyName.Add(9, "col9");

                    break;

                #endregion

                #region Allhezuo1

                case "Allhezuo1":

                    // 基本外觀
                    this.Title = "合作单位检索画面";
                    this.Criteria = "合作单位";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllhezuo1";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "支付对象");
                    this.ColumnText.Add(2, "收款人");
                    this.ColumnText.Add(3, "开户行");
                    this.ColumnText.Add(4, "银行账号");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");

                    break;

                #endregion

                #region Alljiesuan

                case "Alljiesuan":

                    // 基本外觀
                    this.Title = "结算管理检索画面";
                    this.Criteria = "项目名称";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAlljiesuan";

                    // 欄位顯示名稱
                    this.ColumnText.Add(9, "结算单号");

                    this.ColumnText.Add(1, "项目名称");
                    this.ColumnText.Add(2, "项目编码");
                    this.ColumnText.Add(3, "总包发票金额");
                    this.ColumnText.Add(4, "总包到账金额");
                    this.ColumnText.Add(5, "分包发票金额");
                    this.ColumnText.Add(6, "分包到账金额");
                    this.ColumnText.Add(7, "劳务单位开票金额");
                    this.ColumnText.Add(8, "已经支付金额");

                    // 欄位是否顯示
                    this.ColumnVisible.Add(9, true);

                    this.ColumnVisible.Add(1, true);
                    this.ColumnVisible.Add(2, true);
                    this.ColumnVisible.Add(3, true);
                    this.ColumnVisible.Add(4, true);
                    this.ColumnVisible.Add(5, false);
                    this.ColumnVisible.Add(6, false);
                    this.ColumnVisible.Add(7, false);
                    this.ColumnVisible.Add(8, true);

                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致
                    this.PropertyName.Add(9, "col9");
                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                    this.PropertyName.Add(3, "col3");
                    this.PropertyName.Add(4, "col4");
                    this.PropertyName.Add(5, "col5");
                    this.PropertyName.Add(6, "col6");
                    this.PropertyName.Add(7, "col7");
                    this.PropertyName.Add(8, "col8");

                    break;

                #endregion

                #region Allshenherenyuan

                case "Allshenherenyuan":

                    // 基本外觀
                    this.Title = "审核人员检索画面";
                    this.Criteria = "审核人员";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllshenherenyuan";

                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "审核人员");
                    this.ColumnText.Add(2, "审核员");

                    // 欄位是否顯示

                    this.ColumnVisible.Add(1, false);
                    this.ColumnVisible.Add(2, true);


                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致

                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");
                   
                    break;

                #endregion

                #region Allshenherenyuan2

                case "Allshenherenyuan2":

                    // 基本外觀
                    this.Title = "审核人员检索画面";
                    this.Criteria = "审核人员";
                    this.CriteriaToolTip = "";

                    // 執行查詢的 Method Name
                    this.QueryMethodName = "SearchAllshenherenyuan2";

                    // 欄位顯示名稱
                    // 欄位顯示名稱
                    this.ColumnText.Add(1, "审核人员");
                    this.ColumnText.Add(2, "审核员");

                    // 欄位是否顯示

                    this.ColumnVisible.Add(1, false);
                    this.ColumnVisible.Add(2, true);


                    // 定義傳出去的 javascript Object 的 Property 名稱，取名的意義須與顯示欄位的順序一致

                    this.PropertyName.Add(1, "col1");
                    this.PropertyName.Add(2, "col2");

                    break;

                #endregion

                default:
                    this.QueryMethodName = "";
                    break;
            }
        }

        #endregion
    }

}
