using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Erps.Dashboard
{
    public partial class dash : System.Web.UI.Page
    {
        public SqlConnection myConnection = new SqlConnection();
        public SqlDataAdapter adp;
        public SqlCommand cmd;

        public void getstats()
        {

            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["connpath"].ConnectionString;

            DataSet ds = new DataSet();
            int i = 0;
            cmd = new SqlCommand("declare @custodian nvarchar(50)='OMCUS';declare @company nvarchar(50)='OMZIL'; select (select count(*) from accounts_clients where custodian=@custodian) AS [TotalRegistration] ,ISNULL((select sum(amount) from tbl_cashbalance where clientid in (select cds_number from accounts_clients where custodian=@custodian)),0) as [totalfunds], (select sum(shares) from trans where cds_number in (select cds_number from accounts_clients where custodian=@custodian) and company=@company) as [totalholdings], 0 AS CDCHOLDINGS, ISNULL((SELECT SUM(quantity) FROM TESTCDS.DBO.LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='SELL'),0) AS [Incomingsells],ISNULL((SELECT SUM(quantity) FROM TESTCDS.DBO.LIVETRADINGMASTER  where cds_ac_no in (select cds_number from accounts_clients where custodian=@custodian) and company=@company and OrderType='BUY'),0) AS [Incomingbuys],(  select isnull(sum(tradeqty),0) from tblmatchedorders where banksent='0' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company) as [Pendingsettlement],(  select isnull(sum(tradeqty),0) from tblmatchedorders where ack='SETTLED' and (account1 in (select cds_number from accounts_clients where custodian=@custodian) or account2 in (select cds_number from accounts_clients where custodian=@custodian)) and company=@company and convert(date,SettlementDate)=convert(date,getdate()))  as [todaysettlement]", myConnection);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "stats");

            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                lbltotal_registrations.InnerText = myRow["TotalRegistration"].ToString();
                lbltotal_funds.InnerText = "$" + myRow["totalfunds"].ToString();
                lbldepositoryholdings.InnerText = myRow["CDCHOLDINGS"].ToString();
                lbltotal_holdings.InnerText = myRow["totalholdings"].ToString();
                lblincomingsells.InnerText = myRow["Incomingsells"].ToString();
                lblincomingbuys.InnerText = myRow["Incomingbuys"].ToString();
                lblpendingsettlement.InnerText = myRow["Pendingsettlement"].ToString();
                lbltodaysettled.InnerText = myRow["todaysettlement"].ToString();

            }

        }

        public void loadgriview()
        {
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["connpath"].ConnectionString;

            DataSet ds = new DataSet();
            int i = 0;
            cmd = new SqlCommand("select cds_number, brokercode,  left(isnull(surname,'')+' '+isnull(forenames,''),20) as [fullname], idnopp, custodian, mobile  from accounts_clients where custodian='OMCUS' ORDER BY ID DESC", myConnection);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "namesclients");
            int num = 0;
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {

                if (num == 0)
                {
                    name1.InnerText = myRow["fullname"].ToString();
                    cds1.InnerText = myRow["cds_Number"].ToString();
                    phone1.InnerText = myRow["mobile"].ToString();
                    broker1.InnerText = myRow["brokercode"].ToString();
                    idnumber1.InnerText = myRow["idnopp"].ToString();

                }
                if (num == 1)
                {
                    name2.InnerText = myRow["fullname"].ToString();
                    cds2.InnerText = myRow["cds_Number"].ToString();
                    phone2.InnerText = myRow["mobile"].ToString();
                    broker2.InnerText = myRow["brokercode"].ToString();
                    idnumber2.InnerText = myRow["idnopp"].ToString();

                }

                if (num == 2)
                {
                    name3.InnerText = myRow["fullname"].ToString();
                    cds3.InnerText = myRow["cds_Number"].ToString();
                    phone3.InnerText = myRow["mobile"].ToString();
                    broker3.InnerText = myRow["brokercode"].ToString();
                    idnumber3.InnerText = myRow["idnopp"].ToString();

                }

                if (num == 3)
                {
                    name4.InnerText = myRow["fullname"].ToString();
                    cds4.InnerText = myRow["cds_Number"].ToString();
                    phone4.InnerText = myRow["mobile"].ToString();
                    broker4.InnerText = myRow["brokercode"].ToString();
                    idnumber4.InnerText = myRow["idnopp"].ToString();

                }

                if (num == 4)
                {
                    name5.InnerText = myRow["fullname"].ToString();
                    cds5.InnerText = myRow["cds_Number"].ToString();
                    phone5.InnerText = myRow["mobile"].ToString();
                    broker5.InnerText = myRow["brokercode"].ToString();
                    idnumber5.InnerText = myRow["idnopp"].ToString();

                }

                if (num == 5)
                {
                    name6.InnerText = myRow["fullname"].ToString();
                    cds6.InnerText = myRow["cds_Number"].ToString();
                    phone6.InnerText = myRow["mobile"].ToString();
                    broker6.InnerText = myRow["brokercode"].ToString();
                    idnumber6.InnerText = myRow["idnopp"].ToString();

                }
                if (num == 6)
                {
                    name7.InnerText = myRow["fullname"].ToString();
                    cds7.InnerText = myRow["cds_Number"].ToString();
                    phone7.InnerText = myRow["mobile"].ToString();
                    broker7.InnerText = myRow["brokercode"].ToString();
                    idnumber7.InnerText = myRow["idnopp"].ToString();

                }

                num++;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                prog1.Attributes.CssStyle.Value = "width: 100%;";
                loadgriview();
                getstats();
            }
            catch (Exception ex)
            {
                msgbox(ex.Message);
            }
        }

        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }

    }
}