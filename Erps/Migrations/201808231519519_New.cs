namespace Erps.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account_CreationPending",
                c => new
                {
                    ID_ = c.Int(nullable: false, identity: true),
                    RecordType = c.String(),
                    ClientSuffix = c.String(maxLength: 255),
                    JointAcc = c.String(maxLength: 255),
                    Identification = c.String(maxLength: 255),
                    Title = c.String(maxLength: 255),
                    Initials = c.String(maxLength: 255),
                    OtherNames = c.String(maxLength: 255),
                    Surname_CompanyName = c.String(maxLength: 255),
                    Address1 = c.String(maxLength: 255),
                    Address2 = c.String(maxLength: 255),
                    Address3 = c.String(maxLength: 255),
                    Town = c.String(maxLength: 255),
                    PostCode = c.String(maxLength: 255),
                    FaxNumber = c.String(maxLength: 255),
                    Emailaddress = c.String(maxLength: 255),
                    DateofBirth_Incorporation = c.DateTime(storeType: "date"),
                    Gender = c.String(maxLength: 255),
                    Nationality = c.String(maxLength: 255),
                    Resident = c.String(maxLength: 255),
                    TaxBracket = c.Decimal(precision: 18, scale: 2),
                    TelephoneNumber = c.String(maxLength: 255),
                    Bank = c.String(maxLength: 255),
                    Branch = c.String(maxLength: 255),
                    ClientType = c.String(maxLength: 255),
                    CDSC_Number = c.String(maxLength: 255),
                    Notification_Sent = c.Int(),
                    Callback_Endpoint = c.String(maxLength: 255),
                    MNO_ = c.String(maxLength: 255),
                    Date_Created = c.DateTime(),
                    File_Sent_DirectDebt = c.Int(),
                    File_Sent_AccountCr = c.Int(),
                    PIN_No = c.String(maxLength: 255),
                    Middlename = c.String(maxLength: 255),
                    RNum = c.String(maxLength: 255),
                    MobileNumber = c.String(maxLength: 100),
                    Bankname = c.String(),
                    Bankcode = c.String(),
                    BranchName = c.String(),
                    BranchCode = c.String(),
                    Accountnumber = c.String(maxLength: 255),
                    idtype = c.String(),
                    accountcategory = c.String(),
                    country = c.String(),
                    currency = c.String(),
                    divpayee = c.String(),
                    divbank = c.String(),
                    divbankcode = c.String(),
                    divbranch = c.String(),
                    divbranchcode = c.String(),
                    divacc = c.String(),
                    divaccounttype = c.String(),
                    idtype2 = c.String(),
                    dividnumber = c.String(),
                    mobile_money = c.String(),
                    depname = c.String(),
                    depcode = c.String(),
                    manBank = c.String(),
                    manBankCode = c.String(),
                    manBranch = c.String(),
                    manBranchCode = c.String(),
                    manAccount = c.String(),
                    manNames = c.String(),
                    manAddress = c.String(),
                    mobilewalletnumber = c.String(),
                    Broker = c.String(),
                    update_type = c.String(),
                    ModifiedBy = c.String(),
                    CreatedBy = c.String(),
                    StatuSActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID_);

            CreateTable(
                "dbo.Account_Creation",
                c => new
                {
                    ID_ = c.Int(nullable: false, identity: true),
                    RecordType = c.String(),
                    ClientSuffix = c.String(maxLength: 255),
                    JointAcc = c.String(maxLength: 255),
                    Identification = c.String(maxLength: 255),
                    Title = c.String(maxLength: 255),
                    Initials = c.String(maxLength: 255),
                    OtherNames = c.String(maxLength: 255),
                    Surname_CompanyName = c.String(maxLength: 255),
                    Address1 = c.String(maxLength: 255),
                    Address2 = c.String(maxLength: 255),
                    Address3 = c.String(maxLength: 255),
                    Town = c.String(maxLength: 255),
                    PostCode = c.String(maxLength: 255),
                    FaxNumber = c.String(maxLength: 255),
                    Emailaddress = c.String(maxLength: 255),
                    DateofBirth_Incorporation = c.DateTime(storeType: "date"),
                    Gender = c.String(maxLength: 255),
                    Nationality = c.String(maxLength: 255),
                    Resident = c.String(maxLength: 255),
                    TaxBracket = c.Decimal(precision: 18, scale: 2),
                    TelephoneNumber = c.String(maxLength: 255),
                    Bank = c.String(maxLength: 255),
                    Branch = c.String(maxLength: 255),
                    ClientType = c.String(maxLength: 255),
                    CDSC_Number = c.String(maxLength: 255),
                    Notification_Sent = c.Int(),
                    Callback_Endpoint = c.String(maxLength: 255),
                    MNO_ = c.String(maxLength: 255),
                    Date_Created = c.DateTime(),
                    File_Sent_DirectDebt = c.Int(),
                    File_Sent_AccountCr = c.Int(),
                    PIN_No = c.String(maxLength: 255),
                    Middlename = c.String(maxLength: 255),
                    RNum = c.String(maxLength: 255),
                    MobileNumber = c.String(maxLength: 100),
                    Bankname = c.String(),
                    Bankcode = c.String(),
                    BranchName = c.String(),
                    BranchCode = c.String(),
                    Accountnumber = c.String(maxLength: 255),
                    idtype = c.String(),
                    accountcategory = c.String(),
                    country = c.String(),
                    currency = c.String(),
                    divpayee = c.String(),
                    divbank = c.String(),
                    divbankcode = c.String(),
                    divbranch = c.String(),
                    divbranchcode = c.String(),
                    divacc = c.String(),
                    divaccounttype = c.String(),
                    idtype2 = c.String(),
                    dividnumber = c.String(),
                    mobile_money = c.String(),
                    depname = c.String(),
                    depcode = c.String(),
                    manBank = c.String(),
                    manBankCode = c.String(),
                    manBranch = c.String(),
                    manBranchCode = c.String(),
                    manAccount = c.String(),
                    manNames = c.String(),
                    manAddress = c.String(),
                    mobilewalletnumber = c.String(),
                    Broker = c.String(),
                    CreatedBy = c.String(),
                    StatuSActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID_);

            CreateTable(
                "dbo.AccountMaintenance",
                c => new
                {
                    AccountMaintenanceID = c.Int(nullable: false, identity: true),
                    account_type = c.String(),
                    amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    frequency = c.String(),
                })
                .PrimaryKey(t => t.AccountMaintenanceID);

            CreateTable(
                "dbo.Accounts_Documents",
                c => new
                {
                    Accounts_DocumentsID = c.Int(nullable: false, identity: true),
                    doc_generated = c.String(),
                    Name = c.String(maxLength: 255),
                    ContentType = c.String(maxLength: 255),
                    Data = c.Binary(),
                })
                .PrimaryKey(t => t.Accounts_DocumentsID);

            CreateTable(
                "dbo.Accounts_Joint",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Surname = c.String(),
                    Forenames = c.String(),
                    IDNo = c.String(),
                    IDType = c.String(),
                    Nationality = c.String(),
                    DateOfBirth = c.DateTime(),
                    Gender = c.String(),
                    CDSNo = c.String(),
                    email = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Accounts_Master",
                c => new
                {
                    Accounts_MasterID = c.Int(nullable: false, identity: true),
                    AccountName = c.String(),
                    AccountNumber = c.Int(nullable: false),
                    GL_GroupID = c.Int(),
                    GroupName = c.String(),
                    Description = c.String(),
                    Code = c.String(),
                    FinancialStatement = c.String(),
                    GeneralLedgerAccount = c.String(),
                    DebitOrCredit = c.String(),
                })
                .PrimaryKey(t => t.Accounts_MasterID);

            CreateTable(
                "dbo.ActionFormcs",
                c => new
                {
                    ActionFormID = c.Int(nullable: false, identity: true),
                    ClientPortfoliosID = c.Int(nullable: false),
                    ClientNumber = c.String(),
                    ClientNames = c.String(),
                    clientholdings = c.Double(nullable: false),
                    Date = c.DateTime(),
                    hour = c.String(),
                    minutes = c.String(),
                    setting = c.String(),
                    contactnotes = c.String(),
                    adviceclient = c.String(),
                    contacttype = c.String(),
                })
                .PrimaryKey(t => t.ActionFormID);

            CreateTable(
                "dbo.AdjustedHoldings",
                c => new
                {
                    AdjustedHoldingsID = c.Int(nullable: false, identity: true),
                    Buyer = c.String(),
                    seller = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Dates = c.DateTime(nullable: false),
                    TradeID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AdjustedHoldingsID);

            CreateTable(
                "dbo.Agent",
                c => new
                {
                    AgentID = c.Int(nullable: false, identity: true),
                    AgentCode = c.String(),
                    AgentName = c.String(nullable: false),
                    PracticingID = c.String(),
                    Email = c.String(nullable: false, maxLength: 35),
                    address = c.String(nullable: false),
                    mobilenumber = c.String(),
                    telephone = c.String(),
                    status = c.String(),
                    AgentType = c.String(nullable: false),
                })
                .PrimaryKey(t => t.AgentID);

            CreateTable(
                "dbo.ApplicationCapture",
                c => new
                {
                    ApplicationCaptureID = c.Int(nullable: false, identity: true),
                    BatchRef = c.String(),
                    BatchID = c.Int(nullable: false),
                    BatchTotal = c.Double(nullable: false),
                    ClientNumber = c.String(),
                    ClientNames = c.String(),
                    ClientID = c.String(),
                    ClientUnits = c.Double(nullable: false),
                    value = c.Double(nullable: false),
                    tempstatus = c.String(),
                })
                .PrimaryKey(t => t.ApplicationCaptureID);

            CreateTable(
                "dbo.AuditLog",
                c => new
                {
                    AuditLogId = c.Long(nullable: false, identity: true),
                    UserName = c.String(),
                    EventDateUTC = c.DateTime(nullable: false),
                    EventType = c.Int(nullable: false),
                    TypeFullName = c.String(nullable: false, maxLength: 512),
                    RecordId = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.AuditLogId);

            CreateTable(
                "dbo.AuditLogDetail",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    PropertyName = c.String(nullable: false, maxLength: 256),
                    OriginalValue = c.String(),
                    NewValue = c.String(),
                    AuditLogId = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLog", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);

            CreateTable(
                "dbo.LogMetadata",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    AuditLogId = c.Long(nullable: false),
                    Key = c.String(),
                    Value = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLog", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);

            CreateTable(
                "dbo.para_bank",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    bank = c.String(),
                    bank_name = c.String(),
                    eft = c.Boolean(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.batch_mast",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    batch_no = c.String(nullable: false),
                    batch_type = c.String(),
                    app_shares = c.Decimal(nullable: false, precision: 18, scale: 2),
                    app_cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                    status = c.String(),
                    Company = c.String(nullable: false),
                    Agent = c.String(nullable: false),
                    BrokerBatchRef = c.String(),
                    Verify = c.Boolean(),
                    CreatedBy = c.String(nullable: false),
                    apps = c.String(nullable: false),
                    branch = c.String(),
                    datecreated = c.DateTime(),
                    PayMode = c.String(),
                    dateauth = c.DateTime(),
                    BoxNo = c.Decimal(precision: 18, scale: 2),
                    OldBatchRef = c.String(),
                    Source = c.String(),
                    WebResponse = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.BatchApplication",
                c => new
                {
                    BatchApplicationID = c.Int(nullable: false, identity: true),
                    ClientName = c.String(),
                    ClientAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    numberofshares = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Clientnumber = c.String(),
                    BatchNo = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.BatchApplicationID);

            CreateTable(
                "dbo.BatchDeals",
                c => new
                {
                    BatchDealsID = c.Int(nullable: false, identity: true),
                    Deal = c.String(),
                    myDD = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.BatchDealsID);

            CreateTable(
                "dbo.Batch",
                c => new
                {
                    BatchID = c.Int(nullable: false, identity: true),
                    Batchref = c.String(nullable: false),
                    BatchUnits = c.Double(nullable: false),
                    BatchDetails = c.String(nullable: false),
                    tempstatus = c.String(),
                    product = c.String(),
                    IPOID = c.Int(nullable: false),
                    value = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.BatchID);

            CreateTable(
                "dbo.BatchHeader",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    BatchNo = c.String(),
                    BatchType = c.String(),
                    Amount = c.Decimal(nullable: false, storeType: "money"),
                    NumberOfTrxns = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    DateCreated = c.DateTime(),
                    Status = c.Boolean(nullable: false),
                    Auth = c.Boolean(nullable: false),
                    BatchName = c.String(),
                    BatchDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.BatchTransaction",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    TrxnDate = c.DateTime(nullable: false),
                    Reference = c.String(),
                    Description = c.String(),
                    Amount = c.Decimal(nullable: false, storeType: "money"),
                    BankID = c.String(),
                    BankAccName = c.String(),
                    BatchNo = c.String(),
                    AccountName = c.String(),
                    Account = c.String(),
                    AccountNameD = c.String(),
                    AccountD = c.String(),
                    Commit = c.Boolean(nullable: false),
                    Auth = c.Boolean(nullable: false),
                    trantype = c.String(),
                    trantypeD = c.String(),
                    filename = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.UplodedTrans",
                c => new
                {
                    UplodedTransID = c.Int(nullable: false, identity: true),
                    TransactionDate = c.DateTime(nullable: false),
                    ValueDate = c.DateTime(nullable: false),
                    Reference = c.String(),
                    Description = c.String(),
                    Debit = c.Decimal(nullable: false, storeType: "money"),
                    Credit = c.Decimal(nullable: false, storeType: "money"),
                    Balance = c.Decimal(nullable: false, storeType: "money"),
                    clientnumber = c.String(),
                    fileName = c.String(),
                    UploadedBy = c.String(),
                    UploadedDate = c.DateTime(nullable: false),
                    Batch = c.String(),
                    reason = c.String(),
                    transID = c.String(),
                })
                .PrimaryKey(t => t.UplodedTransID);

            CreateTable(
                "dbo.para_branch",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    bank = c.String(maxLength: 50),
                    branch = c.String(maxLength: 50),
                    branch_name = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Brokerage",
                c => new
                {
                    BrokerageID = c.Int(nullable: false, identity: true),
                    CompanyName = c.String(nullable: false),
                    OperatingAddress = c.String(nullable: false),
                    PrincipalAgent = c.String(nullable: false),
                    brokername = c.String(),
                })
                .PrimaryKey(t => t.BrokerageID);

            CreateTable(
                "dbo.BrokerClass",
                c => new
                {
                    BrokerClassID = c.Int(nullable: false, identity: true),
                    BrokerName = c.String(),
                    ATPCSD = c.String(),
                })
                .PrimaryKey(t => t.BrokerClassID);

            CreateTable(
                "dbo.BrokerLimit",
                c => new
                {
                    BrokerLimitID = c.Int(nullable: false, identity: true),
                    BuyLimit = c.Decimal(nullable: false, storeType: "money"),
                    SellLimit = c.Decimal(nullable: false, storeType: "money"),
                    reaction = c.String(nullable: false),
                })
                .PrimaryKey(t => t.BrokerLimitID);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    region_id = c.Int(nullable: false),
                    country_id = c.Int(nullable: false),
                    latitude = c.Int(nullable: false),
                    longitude = c.Double(nullable: false),
                    name = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Client_Companies",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Company_name = c.String(),
                    Company_Code = c.String(),
                    Company_type = c.String(),
                    AccountManager = c.String(),
                    Account_Pass = c.String(),
                    Adress_1 = c.String(),
                    Adress_2 = c.String(),
                    Adress_3 = c.String(),
                    Adress_4 = c.String(),
                    adress_5 = c.String(),
                    contact_email = c.String(),
                    contact_phone = c.String(),
                    contact_person = c.String(),
                    Job = c.String(),
                    status = c.Boolean(),
                    main_branch = c.String(),
                    main_account = c.String(),
                    trading_branch = c.String(),
                    trading_account = c.String(),
                    main_account_name = c.String(),
                    trading_account_name = c.String(),
                    trading_bank = c.String(),
                    main_bank = c.String(),
                    settlement_cycle = c.Int(),
                    main_branch_new = c.String(),
                    trading_branch_new = c.String(),
                    key_letter = c.String(),
                    CDS_Number = c.String(),
                    Broker_Custodian = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Client_Types",
                c => new
                {
                    Client_TypesID = c.Int(nullable: false, identity: true),
                    ClientType = c.String(),
                    TaxCode = c.String(nullable: false),
                    Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Client_TypesID);

            CreateTable(
                "dbo.ClientPortfolios",
                c => new
                {
                    ClientPortfoliosID = c.Int(nullable: false, identity: true),
                    ClientNumber = c.String(nullable: false),
                    Stock = c.String(nullable: false),
                    Holdings = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Stockf = c.String(),
                    Clientf = c.String(),
                })
                .PrimaryKey(t => t.ClientPortfoliosID);

            CreateTable(
                "dbo.ClientsDue",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    names = c.String(),
                    accountnumber = c.String(),
                    amounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.CompanyEarners",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    companyname = c.String(),
                    brokername = c.String(),
                    consideration = c.Decimal(nullable: false, precision: 18, scale: 2),
                    commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                    tradeType = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.CompanySecurity",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Security_Type = c.String(nullable: false),
                    Description = c.String(),
                    CompanyName = c.String(nullable: false),
                    CompanyID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.para_country",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    country = c.String(maxLength: 50),
                    fnam = c.String(maxLength: 50),
                    Nationality = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    code = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.DealerDG",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Security = c.String(),
                    Deal = c.String(),
                    Quantity = c.String(),
                    Price = c.String(),
                    Account1 = c.String(),
                    Account2 = c.String(),
                    DatePosted = c.String(),
                    SettlementDate = c.String(),
                    Ack = c.String(),
                    AccountName1 = c.String(),
                    AccountName2 = c.String(),
                    SecurityName = c.String(),
                    Exchange = c.String(),
                    Printed = c.Boolean(nullable: false),
                    Status = c.String(),
                    SettDate = c.DateTime(),
                    PostDate = c.DateTime(),
                    DealNumber = c.Int(),
                    OrderNumber = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.DealerDG2",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Security = c.String(),
                    Deal = c.String(),
                    Quantity = c.String(),
                    Price = c.String(),
                    Account1 = c.String(),
                    Account2 = c.String(),
                    DatePosted = c.DateTime(nullable: false),
                    SettlementDate = c.String(),
                    Ack = c.String(),
                    AccountName1 = c.String(),
                    AccountName2 = c.String(),
                    SecurityName = c.String(),
                    Exchange = c.String(),
                    Printed = c.Boolean(nullable: false),
                    Status = c.String(),
                    OldDeal = c.String(),
                    SettDate = c.DateTime(),
                    PostDate = c.DateTime(),
                    OrderNumber = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Deposits",
                c => new
                {
                    DepositsID = c.Int(nullable: false, identity: true),
                    CDSNUmber = c.String(nullable: false),
                    TranDate = c.DateTime(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.DepositsID);

            CreateTable(
                "dbo.Depository",
                c => new
                {
                    DepositoryID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Country = c.String(nullable: false),
                    City = c.String(nullable: false),
                    State = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    StateID = c.Int(nullable: false),
                    CountryID = c.Int(nullable: false),
                    CityID = c.Int(nullable: false),
                    PhoneNumber = c.String(),
                })
                .PrimaryKey(t => t.DepositoryID);

            CreateTable(
                "dbo.div_types",
                c => new
                {
                    div_typesID = c.Int(nullable: false, identity: true),
                    DivType = c.String(),
                    DiviTypeName = c.String(),
                })
                .PrimaryKey(t => t.div_typesID);

            CreateTable(
                "dbo.FinancialStatements",
                c => new
                {
                    FinancialStatementsID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.FinancialStatementsID);

            CreateTable(
                "dbo.Frequencies",
                c => new
                {
                    FrequenciesID = c.Int(nullable: false, identity: true),
                    FrequencyName = c.String(),
                    FrequencyCode = c.String(),
                })
                .PrimaryKey(t => t.FrequenciesID);

            CreateTable(
                "dbo.GeneralLedgerAcc",
                c => new
                {
                    GeneralLedgerAccID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.GeneralLedgerAccID);

            CreateTable(
                "dbo.GL_Group",
                c => new
                {
                    GL_GroupID = c.Int(nullable: false, identity: true),
                    GroupName = c.String(nullable: false),
                    StartingAccount = c.Int(nullable: false),
                    EndingAccount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.GL_GroupID);

            CreateTable(
                "dbo.glyphicon",
                c => new
                {
                    glyphiconID = c.Int(nullable: false, identity: true),
                    glyphiconname = c.String(),
                })
                .PrimaryKey(t => t.glyphiconID);

            CreateTable(
                "dbo.IDTypes",
                c => new
                {
                    IDTypesID = c.Int(nullable: false, identity: true),
                    idname = c.String(),
                })
                .PrimaryKey(t => t.IDTypesID);

            CreateTable(
                "dbo.IPO",
                c => new
                {
                    IPOID = c.Int(nullable: false, identity: true),
                    issuer = c.String(nullable: false),
                    targetedvalue = c.Double(nullable: false),
                    OpenningDate = c.DateTime(nullable: false),
                    ClosingDate = c.DateTime(nullable: false),
                    ListingDate = c.DateTime(nullable: false),
                    openningprice = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.IPOID);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessagesID = c.Int(nullable: false, identity: true),
                    Subject = c.String(),
                    Description = c.String(),
                    User = c.String(),
                    UserID = c.String(),
                    fromUser = c.String(),
                    fromUserID = c.String(),
                    DateAdded = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.MessagesID);

            CreateTable(
                "dbo.Modules",
                c => new
                {
                    ModulesID = c.Int(nullable: false, identity: true),
                    ModulesName = c.String(nullable: false),
                    RoleID = c.Int(nullable: false),
                    glyphicon = c.String(),
                    ControllerName = c.String(),
                    ViewName = c.String(),
                    Name = c.String(nullable: false),
                    IsWebForm = c.Boolean(nullable: false),
                    webFormUrl = c.String(),
                    MenuRank = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ModulesID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    RoleId = c.Int(nullable: false, identity: true),
                    RoleName = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.RoleId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    Email = c.String(nullable: false, maxLength: 35),
                    Password = c.String(nullable: false),
                    ConfirmPassword = c.String(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LockCount = c.Int(nullable: false),
                    CreateDate = c.DateTime(),
                    role = c.String(nullable: false),
                    BrokerName = c.String(),
                    BrokerCode = c.String(),
                })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Email, unique: true);

            CreateTable(
                "dbo.notification",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    userid = c.Int(nullable: false),
                    notification_type = c.String(),
                    notification_data = c.String(),
                    timestamp = c.DateTime(),
                    last_read = c.String(),
                    fromsysytem = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Order_Live",
                c => new
                {
                    OrderNo = c.Long(nullable: false, identity: true),
                    OrderType = c.String(),
                    Company = c.String(),
                    SecurityType = c.String(),
                    CDS_AC_No = c.String(),
                    Broker_Code = c.String(),
                    Client_Type = c.String(),
                    Tax = c.Decimal(precision: 18, scale: 2),
                    Shareholder = c.String(),
                    ClientName = c.String(),
                    TotalShareHolding = c.Decimal(precision: 18, scale: 2),
                    OrderStatus = c.String(),
                    Create_date = c.DateTime(),
                    Deal_Begin_Date = c.DateTime(),
                    Expiry_Date = c.DateTime(),
                    Quantity = c.Int(),
                    BasePrice = c.Decimal(storeType: "money"),
                    AvailableShares = c.Decimal(precision: 18, scale: 2),
                    OrderPref = c.String(),
                    OrderAttribute = c.String(),
                    Marketboard = c.String(),
                    TimeInForce = c.String(),
                    OrderQualifier = c.String(),
                    BrokerRef = c.String(),
                    ContraBrokerId = c.String(),
                    MaxPrice = c.Decimal(storeType: "money"),
                    MiniPrice = c.Decimal(storeType: "money"),
                    Flag_oldorder = c.Boolean(),
                    OrderNumber = c.String(),
                    Currency = c.String(),
                    CompanyID = c.Int(nullable: false),
                    CompanyISIN = c.String(),
                    TP = c.String(),
                    TPBoard = c.String(),
                    mobile = c.String(),
                    PostedBy = c.String(),
                    WebServiceID = c.String(),
                })
                .PrimaryKey(t => t.OrderNo);

            CreateTable(
                "dbo.Order_Lives",
                c => new
                {
                    Order_LivesID = c.Int(nullable: false, identity: true),
                    OrderNo = c.Long(nullable: false),
                    OrderType = c.String(),
                    Company = c.String(),
                    SecurityType = c.String(),
                    CDS_AC_No = c.String(),
                    Broker_Code = c.String(),
                    Client_Type = c.String(),
                    Tax = c.Decimal(precision: 18, scale: 2),
                    Shareholder = c.String(),
                    ClientName = c.String(),
                    TotalShareHolding = c.Int(),
                    OrderStatus = c.String(),
                    Create_date = c.DateTime(),
                    Deal_Begin_Date = c.DateTime(),
                    Expiry_Date = c.DateTime(),
                    Quantity = c.Int(),
                    BasePrice = c.Decimal(precision: 18, scale: 2),
                    AvailableShares = c.Int(),
                    OrderPref = c.String(),
                    OrderAttribute = c.String(),
                    Marketboard = c.String(),
                    TimeInForce = c.String(),
                    OrderQualifier = c.String(),
                    BrokerRef = c.String(),
                    ContraBrokerId = c.String(),
                    MaxPrice = c.Decimal(precision: 18, scale: 2),
                    MiniPrice = c.Decimal(precision: 18, scale: 2),
                    Flag_oldorder = c.Boolean(),
                    OrderNumber = c.String(),
                    Currency = c.String(),
                    FOK = c.Boolean(),
                    Affirmation = c.Boolean(),
                })
                .PrimaryKey(t => t.Order_LivesID);

            CreateTable(
                "dbo.para_Currencies",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    CurrencyCode = c.String(),
                    CurrencyName = c.String(),
                    CurrencySymbol = c.String(),
                    InternationalSTD = c.String(),
                    CurrencyStatus = c.String(),
                    Country = c.String(),
                    Pref = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.para_issuer",
                c => new
                {
                    para_issuerID = c.Int(nullable: false, identity: true),
                    Company = c.String(nullable: false),
                    Date_created = c.DateTime(),
                    Issued_shares = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    Status = c.Boolean(),
                    registrar = c.String(maxLength: 50),
                    Add_1 = c.String(nullable: false),
                    City = c.String(nullable: false, maxLength: 50),
                    Country = c.String(nullable: false, maxLength: 50),
                    State = c.String(nullable: false),
                    Contact_Person = c.String(nullable: false, maxLength: 50),
                    Telephone = c.String(maxLength: 50),
                    Cellphone = c.String(maxLength: 50),
                    ISIN = c.String(maxLength: 12),
                    date_listed = c.DateTime(),
                    email = c.String(maxLength: 50),
                    website = c.String(maxLength: 50),
                    StateID = c.Int(nullable: false),
                    CountryID = c.Int(nullable: false),
                    CityID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.para_issuerID);

            CreateTable(
                "dbo.ParticipantType",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Type = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Permission",
                c => new
                {
                    PermissionID = c.Int(nullable: false, identity: true),
                    ControllerName = c.String(),
                    ViewName = c.String(),
                    Name = c.String(nullable: false),
                    assignedRole = c.String(nullable: false),
                    Module = c.String(nullable: false),
                    IsDashboard = c.Boolean(nullable: false),
                    IsWebForm = c.Boolean(nullable: false),
                    webFormUrl = c.String(),
                    IsActice = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.PermissionID);

            CreateTable(
                "dbo.Pre_Order",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    OrderNo = c.Long(nullable: false),
                    OrderType = c.String(),
                    Company = c.String(),
                    SecurityType = c.String(),
                    CDS_AC_No = c.String(),
                    Broker_Code = c.String(),
                    Client_Type = c.String(),
                    Tax = c.Decimal(precision: 18, scale: 2),
                    Shareholder = c.String(),
                    ClientName = c.String(),
                    TotalShareHolding = c.Int(),
                    OrderStatus = c.String(),
                    Create_date = c.DateTime(),
                    Deal_Begin_Date = c.DateTime(),
                    Expiry_Date = c.DateTime(),
                    Quantity = c.Int(),
                    BasePrice = c.Decimal(precision: 18, scale: 2),
                    AvailableShares = c.Int(),
                    OrderPref = c.String(),
                    OrderAttribute = c.String(),
                    Marketboard = c.String(),
                    TimeInForce = c.String(),
                    OrderQualifier = c.String(),
                    BrokerRef = c.String(),
                    ContraBrokerId = c.String(),
                    MaxPrice = c.Decimal(precision: 18, scale: 2),
                    MiniPrice = c.Decimal(precision: 18, scale: 2),
                    Flag_oldorder = c.Boolean(),
                    OrderNumber = c.String(),
                    Currency = c.String(),
                    FOK = c.Boolean(),
                    Affirmation = c.Boolean(),
                    trading_platform = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.region",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    code = c.String(),
                    country_id = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Registrar",
                c => new
                {
                    RegistrarID = c.Int(nullable: false, identity: true),
                    ParticipantName = c.String(nullable: false),
                    ParticipantCode = c.String(nullable: false),
                    ParticipantType = c.String(),
                    Address = c.String(nullable: false),
                    Country = c.String(),
                    Telephone = c.String(),
                    Mobile = c.String(),
                    ParticipantEmail = c.String(nullable: false, maxLength: 35),
                    ContactPerson = c.String(nullable: false),
                    MaxUsers = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.RegistrarID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.ScriptRegister",
                c => new
                {
                    ScriptRegisterID = c.Int(nullable: false, identity: true),
                    Exchange = c.String(nullable: false),
                    ClientNames = c.String(nullable: false),
                    ClientNumber = c.String(nullable: false),
                    Counter = c.String(nullable: false),
                    CertificateNumber = c.String(nullable: false),
                    NumberShares = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Status = c.String(),
                })
                .PrimaryKey(t => t.ScriptRegisterID);

            CreateTable(
                "dbo.StockPrices",
                c => new
                {
                    StockPricesID = c.Int(nullable: false, identity: true),
                    StockSecuritiesID = c.Int(nullable: false),
                    LastTradePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Highest_Trade_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Lowest_Trade_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    daterecorded = c.DateTime(),
                    stockisin = c.String(),
                    TP = c.String(nullable: false),
                    TPBoard = c.String(nullable: false),
                })
                .PrimaryKey(t => t.StockPricesID)
                .ForeignKey("dbo.StockSecurities", t => t.StockSecuritiesID, cascadeDelete: true)
                .Index(t => t.StockSecuritiesID);

            CreateTable(
                "dbo.StockSecurities",
                c => new
                {
                    StockSecuritiesID = c.Int(nullable: false, identity: true),
                    StockISIN = c.String(nullable: false),
                    Issuer = c.String(nullable: false),
                    StockType = c.String(nullable: false),
                    description = c.String(),
                    stockQty = c.Int(nullable: false),
                    StockPrice = c.Double(nullable: false),
                    Stockstatus = c.String(),
                    IssuedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.StockSecuritiesID);

            CreateTable(
                "dbo.StockStatus",
                c => new
                {
                    StockStatusID = c.Int(nullable: false, identity: true),
                    stockstatius = c.String(),
                })
                .PrimaryKey(t => t.StockStatusID);

            CreateTable(
                "dbo.StockTypes",
                c => new
                {
                    StockTypesID = c.Int(nullable: false, identity: true),
                    stockname = c.String(),
                })
                .PrimaryKey(t => t.StockTypesID);

            CreateTable(
                "dbo.Task",
                c => new
                {
                    TaskID = c.Int(nullable: false, identity: true),
                    TaskTitle = c.String(nullable: false),
                    TaskDescription = c.String(nullable: false),
                    TaskUser = c.String(nullable: false),
                    TaskUserID = c.Int(nullable: false),
                    percentagedone = c.Decimal(nullable: false, precision: 18, scale: 2),
                    status = c.String(),
                    fromUser = c.String(),
                    fromUserID = c.String(),
                    TaskDue = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.TaskID);

            CreateTable(
                "dbo.Tax",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    isset = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Tbl_MatchedOrders",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Deal = c.Long(),
                    BuyCompany = c.String(),
                    SellCompany = c.String(),
                    Buyercdsno = c.String(),
                    Sellercdsno = c.String(),
                    Quantity = c.Decimal(precision: 18, scale: 2),
                    Trade = c.DateTime(),
                    DealPrice = c.Decimal(precision: 18, scale: 2),
                    DealFlag = c.String(),
                    instrument = c.String(),
                    RefID = c.Int(nullable: false),
                    BrokerCode = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Tbl_MatchedDeals",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    Deal = c.String(),
                    BuyCompany = c.String(),
                    SellCompany = c.String(),
                    Buyercdsno = c.String(),
                    Sellercdsno = c.String(),
                    Quantity = c.Decimal(precision: 18, scale: 2),
                    Trade = c.DateTime(),
                    DealPrice = c.Decimal(precision: 18, scale: 2),
                    DealFlag = c.String(),
                    Instrument = c.String(),
                    Affirmation = c.Boolean(),
                    buybroker = c.String(),
                    sellbroker = c.String(),
                    RefID = c.Int(nullable: false),
                    BrokerCode = c.String(),
                    BuyerName = c.String(),
                    SellerName = c.String(),
                    exchange = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.TradingBoard",
                c => new
                {
                    TradingBoardID = c.Int(nullable: false, identity: true),
                    BoardCode = c.String(nullable: false),
                    BoardName = c.String(nullable: false),
                    BoardDescription = c.String(),
                })
                .PrimaryKey(t => t.TradingBoardID);

            CreateTable(
                "dbo.TradingPlatform",
                c => new
                {
                    TradingPlatformID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Country = c.String(nullable: false),
                    City = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    PhoneNumber = c.String(),
                    ContactPerson = c.String(),
                    State = c.String(),
                    StateID = c.Int(nullable: false),
                    CountryID = c.Int(nullable: false),
                    CityID = c.Int(nullable: false),
                    Depository = c.String(),
                    TradeBoard = c.String(),
                    TradingBoardID = c.Int(),
                })
                .PrimaryKey(t => t.TradingPlatformID)
                .ForeignKey("dbo.TradingBoard", t => t.TradingBoardID)
                .Index(t => t.TradingBoardID);

            CreateTable(
                "dbo.TradingCharges",
                c => new
                {
                    TradingChargesID = c.Int(nullable: false, identity: true),
                    stockisin = c.String(),
                    StockSecuritieesID = c.Int(nullable: false),
                    chargecode = c.String(),
                    chargedescription = c.String(),
                    tradeside = c.String(),
                    ChargedAs = c.String(),
                    chargevalue = c.Double(),
                    chargefrequency = c.String(),
                    ChargeName = c.String(),
                    chartaccount = c.String(),
                    chargeaccountcode = c.Int(),
                })
                .PrimaryKey(t => t.TradingChargesID);

            CreateTable(
                "dbo.TransactionCharges",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Transcode = c.String(maxLength: 50),
                    ChargeCode = c.String(maxLength: 50),
                    BuyCharges = c.Decimal(storeType: "money"),
                    SellCharges = c.Decimal(storeType: "money"),
                    Date = c.DateTime(storeType: "date"),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Trans",
                c => new
                {
                    TransID = c.Int(nullable: false, identity: true),
                    Type = c.String(),
                    Category = c.String(),
                    TrxnDate = c.DateTime(nullable: false),
                    Account = c.String(nullable: false),
                    Reference_Number = c.String(nullable: false),
                    Narration = c.String(),
                    Debit = c.Decimal(storeType: "money"),
                    Credit = c.Decimal(storeType: "money"),
                    Post = c.DateTime(nullable: false),
                    PostedBy = c.String(),
                })
                .PrimaryKey(t => t.TransID);

            CreateTable(
                "dbo.UplodedDeals",
                c => new
                {
                    UplodedDealsID = c.Int(nullable: false, identity: true),
                    Exchange = c.String(),
                    Market = c.String(),
                    Symbol = c.String(),
                    Trader = c.String(),
                    Client = c.String(),
                    Broker = c.String(),
                    OrderNumber = c.String(),
                    Price = c.String(),
                    Volume = c.String(),
                    TicketNumber = c.String(),
                    ExecutionDateTime = c.DateTime(nullable: false),
                    BuySell = c.String(),
                    ShortSell = c.String(),
                    fileName = c.String(),
                    UploadedBy = c.String(),
                    trans = c.Boolean(nullable: false),
                    TicketNumberN = c.String(),
                })
                .PrimaryKey(t => t.UplodedDealsID);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.WindowsService",
                c => new
                {
                    WindowsServiceID = c.Int(nullable: false, identity: true),
                    AccountName = c.String(),
                    AccountNumber = c.String(),
                    Action = c.String(),
                })
                .PrimaryKey(t => t.WindowsServiceID);

            CreateTable(
                "dbo.Withdrawals",
                c => new
                {
                    WithdrawalsID = c.Int(nullable: false, identity: true),
                    CDSNUmber = c.String(nullable: false),
                    TranDate = c.DateTime(nullable: false),
                    Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.WithdrawalsID);

            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    UserId = c.Int(nullable: false),
                    RoleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TradingPlatform", "TradingBoardID", "dbo.TradingBoard");
            DropForeignKey("dbo.StockPrices", "StockSecuritiesID", "dbo.StockSecurities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.Modules", "RoleID", "dbo.Role");
            DropForeignKey("dbo.LogMetadata", "AuditLogId", "dbo.AuditLog");
            DropForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TradingPlatform", new[] { "TradingBoardID" });
            DropIndex("dbo.StockPrices", new[] { "StockSecuritiesID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.Modules", new[] { "RoleID" });
            DropIndex("dbo.LogMetadata", new[] { "AuditLogId" });
            DropIndex("dbo.AuditLogDetail", new[] { "AuditLogId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Withdrawals");
            DropTable("dbo.WindowsService");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UplodedDeals");
            DropTable("dbo.Trans");
            DropTable("dbo.TransactionCharges");
            DropTable("dbo.TradingCharges");
            DropTable("dbo.TradingPlatform");
            DropTable("dbo.TradingBoard");
            DropTable("dbo.Tbl_MatchedDeals");
            DropTable("dbo.Tbl_MatchedOrders");
            DropTable("dbo.Tax");
            DropTable("dbo.Task");
            DropTable("dbo.StockTypes");
            DropTable("dbo.StockStatus");
            DropTable("dbo.StockSecurities");
            DropTable("dbo.StockPrices");
            DropTable("dbo.ScriptRegister");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Registrar");
            DropTable("dbo.region");
            DropTable("dbo.Pre_Order");
            DropTable("dbo.Permission");
            DropTable("dbo.ParticipantType");
            DropTable("dbo.para_issuer");
            DropTable("dbo.para_Currencies");
            DropTable("dbo.Order_Lives");
            DropTable("dbo.Order_Live");
            DropTable("dbo.notification");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Modules");
            DropTable("dbo.Messages");
            DropTable("dbo.IPO");
            DropTable("dbo.IDTypes");
            DropTable("dbo.glyphicon");
            DropTable("dbo.GL_Group");
            DropTable("dbo.GeneralLedgerAcc");
            DropTable("dbo.Frequencies");
            DropTable("dbo.FinancialStatements");
            DropTable("dbo.div_types");
            DropTable("dbo.Depository");
            DropTable("dbo.Deposits");
            DropTable("dbo.DealerDG2");
            DropTable("dbo.DealerDG");
            DropTable("dbo.Countries");
            DropTable("dbo.para_country");
            DropTable("dbo.CompanySecurity");
            DropTable("dbo.CompanyEarners");
            DropTable("dbo.ClientsDue");
            DropTable("dbo.ClientPortfolios");
            DropTable("dbo.Client_Types");
            DropTable("dbo.Client_Companies");
            DropTable("dbo.Cities");
            DropTable("dbo.BrokerLimit");
            DropTable("dbo.BrokerClass");
            DropTable("dbo.Brokerage");
            DropTable("dbo.para_branch");
            DropTable("dbo.UplodedTrans");
            DropTable("dbo.BatchTransaction");
            DropTable("dbo.BatchHeader");
            DropTable("dbo.Batch");
            DropTable("dbo.BatchDeals");
            DropTable("dbo.BatchApplication");
            DropTable("dbo.batch_mast");
            DropTable("dbo.para_bank");
            DropTable("dbo.LogMetadata");
            DropTable("dbo.AuditLogDetail");
            DropTable("dbo.AuditLog");
            DropTable("dbo.ApplicationCapture");
            DropTable("dbo.Agent");
            DropTable("dbo.AdjustedHoldings");
            DropTable("dbo.ActionFormcs");
            DropTable("dbo.Accounts_Master");
            DropTable("dbo.Accounts_Joint");
            DropTable("dbo.Accounts_Documents");
            DropTable("dbo.AccountMaintenance");
            DropTable("dbo.Account_Creation");
            DropTable("dbo.Account_CreationPending");
        }
    }
}
