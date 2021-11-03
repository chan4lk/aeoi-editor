namespace AEOI.Editor.Web.Shared
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport", IsNullable = false)]
    public partial class AEOIUKSubmissionFIReport
    {

        private AEOIUKSubmissionFIReportMessageData messageDataField;

        private AEOIUKSubmissionFIReportSubmission submissionField;

        private decimal schemaVersionField;

        /// <remarks/>
        public AEOIUKSubmissionFIReportMessageData MessageData
        {
            get
            {
                return this.messageDataField;
            }
            set
            {
                this.messageDataField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmission Submission
        {
            get
            {
                return this.submissionField;
            }
            set
            {
                this.submissionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SchemaVersion
        {
            get
            {
                return this.schemaVersionField;
            }
            set
            {
                this.schemaVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportMessageData
    {

        private string messageCategoryField;

        private System.DateTime xMLTimeStampField;

        private uint aEOIUserIdField;

        /// <remarks/>
        public string MessageCategory
        {
            get
            {
                return this.messageCategoryField;
            }
            set
            {
                this.messageCategoryField = value;
            }
        }

        /// <remarks/>
        public System.DateTime XMLTimeStamp
        {
            get
            {
                return this.xMLTimeStampField;
            }
            set
            {
                this.xMLTimeStampField = value;
            }
        }

        /// <remarks/>
        public uint AEOIUserId
        {
            get
            {
                return this.aEOIUserIdField;
            }
            set
            {
                this.aEOIUserIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmission
    {

        private System.DateTime reportingPeriodField;

        private string messageRefField;

        private AEOIUKSubmissionFIReportSubmissionFIReturn fIReturnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ReportingPeriod
        {
            get
            {
                return this.reportingPeriodField;
            }
            set
            {
                this.reportingPeriodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string MessageRef
        {
            get
            {
                return this.messageRefField;
            }
            set
            {
                this.messageRefField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturn FIReturn
        {
            get
            {
                return this.fIReturnField;
            }
            set
            {
                this.fIReturnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturn
    {

        private AEOIUKSubmissionFIReportSubmissionFIReturnFIReturnAction fIReturnActionField;

        private string fIRegisterIdField;

        private string dueDiligenceIndField;

        private string thresholdIndField;

        private string insuranceElectionField;

        private string dormantAccElectionField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountData[] accountDataField;

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnFIReturnAction FIReturnAction
        {
            get
            {
                return this.fIReturnActionField;
            }
            set
            {
                this.fIReturnActionField = value;
            }
        }

        /// <remarks/>
        public string FIRegisterId
        {
            get
            {
                return this.fIRegisterIdField;
            }
            set
            {
                this.fIRegisterIdField = value;
            }
        }

        /// <remarks/>
        public string DueDiligenceInd
        {
            get
            {
                return this.dueDiligenceIndField;
            }
            set
            {
                this.dueDiligenceIndField = value;
            }
        }

        /// <remarks/>
        public string ThresholdInd
        {
            get
            {
                return this.thresholdIndField;
            }
            set
            {
                this.thresholdIndField = value;
            }
        }

        /// <remarks/>
        public string InsuranceElection
        {
            get
            {
                return this.insuranceElectionField;
            }
            set
            {
                this.insuranceElectionField = value;
            }
        }

        /// <remarks/>
        public string DormantAccElection
        {
            get
            {
                return this.dormantAccElectionField;
            }
            set
            {
                this.dormantAccElectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AccountData")]
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountData[] AccountData
        {
            get
            {
                return this.accountDataField;
            }
            set
            {
                this.accountDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnFIReturnAction
    {

        private string fIReturnRefField;

        private string actionField;

        /// <remarks/>
        public string FIReturnRef
        {
            get
            {
                return this.fIReturnRefField;
            }
            set
            {
                this.fIReturnRefField = value;
            }
        }

        /// <remarks/>
        public string Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountData
    {

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountAction accountActionField;

        private string accountIdentifierField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountNumber accountNumberField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountBalance accountBalanceField;

        private byte accountClosedIndField;

        private byte undocumentedAccountIndField;

        private byte dormantAccountIndField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentData paymentDataField;

        private string accountHolderTypeField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisation organisationField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPerson personField;

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountAction AccountAction
        {
            get
            {
                return this.accountActionField;
            }
            set
            {
                this.accountActionField = value;
            }
        }

        /// <remarks/>
        public string AccountIdentifier
        {
            get
            {
                return this.accountIdentifierField;
            }
            set
            {
                this.accountIdentifierField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountNumber AccountNumber
        {
            get
            {
                return this.accountNumberField;
            }
            set
            {
                this.accountNumberField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountBalance AccountBalance
        {
            get
            {
                return this.accountBalanceField;
            }
            set
            {
                this.accountBalanceField = value;
            }
        }

        /// <remarks/>
        public byte AccountClosedInd
        {
            get
            {
                return this.accountClosedIndField;
            }
            set
            {
                this.accountClosedIndField = value;
            }
        }

        /// <remarks/>
        public byte UndocumentedAccountInd
        {
            get
            {
                return this.undocumentedAccountIndField;
            }
            set
            {
                this.undocumentedAccountIndField = value;
            }
        }

        /// <remarks/>
        public byte DormantAccountInd
        {
            get
            {
                return this.dormantAccountIndField;
            }
            set
            {
                this.dormantAccountIndField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentData PaymentData
        {
            get
            {
                return this.paymentDataField;
            }
            set
            {
                this.paymentDataField = value;
            }
        }

        /// <remarks/>
        public string AccountHolderType
        {
            get
            {
                return this.accountHolderTypeField;
            }
            set
            {
                this.accountHolderTypeField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisation Organisation
        {
            get
            {
                return this.organisationField;
            }
            set
            {
                this.organisationField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPerson Person
        {
            get
            {
                return this.personField;
            }
            set
            {
                this.personField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountAction
    {

        private string accountRefField;

        private string actionField;

        /// <remarks/>
        public string AccountRef
        {
            get
            {
                return this.accountRefField;
            }
            set
            {
                this.accountRefField = value;
            }
        }

        /// <remarks/>
        public string Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountNumber
    {

        private string accountNumberTypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AccountNumberType
        {
            get
            {
                return this.accountNumberTypeField;
            }
            set
            {
                this.accountNumberTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataAccountBalance
    {

        private string currCodeField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currCode
        {
            get
            {
                return this.currCodeField;
            }
            set
            {
                this.currCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentData
    {

        private string paymentCodeField;

        private string paymentTypeDescField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentDataPaymentAmount paymentAmountField;

        /// <remarks/>
        public string PaymentCode
        {
            get
            {
                return this.paymentCodeField;
            }
            set
            {
                this.paymentCodeField = value;
            }
        }

        /// <remarks/>
        public string PaymentTypeDesc
        {
            get
            {
                return this.paymentTypeDescField;
            }
            set
            {
                this.paymentTypeDescField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentDataPaymentAmount PaymentAmount
        {
            get
            {
                return this.paymentAmountField;
            }
            set
            {
                this.paymentAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPaymentDataPaymentAmount
    {

        private string currCodeField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currCode
        {
            get
            {
                return this.currCodeField;
            }
            set
            {
                this.currCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisation
    {

        private string organisationNameField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationAddress addressField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfo holderInfoField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPerson controllingPersonField;

        /// <remarks/>
        public string OrganisationName
        {
            get
            {
                return this.organisationNameField;
            }
            set
            {
                this.organisationNameField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfo HolderInfo
        {
            get
            {
                return this.holderInfoField;
            }
            set
            {
                this.holderInfoField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPerson ControllingPerson
        {
            get
            {
                return this.controllingPersonField;
            }
            set
            {
                this.controllingPersonField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationAddress
    {

        private byte buildingIdentifierField;

        private string streetNameField;

        private string districtNameField;

        private string cityField;

        private string postCodeField;

        private string countryCodeField;

        /// <remarks/>
        public byte BuildingIdentifier
        {
            get
            {
                return this.buildingIdentifierField;
            }
            set
            {
                this.buildingIdentifierField = value;
            }
        }

        /// <remarks/>
        public string StreetName
        {
            get
            {
                return this.streetNameField;
            }
            set
            {
                this.streetNameField = value;
            }
        }

        /// <remarks/>
        public string DistrictName
        {
            get
            {
                return this.districtNameField;
            }
            set
            {
                this.districtNameField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string PostCode
        {
            get
            {
                return this.postCodeField;
            }
            set
            {
                this.postCodeField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfo
    {

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfoIN inField;

        private string resCountryCodeField;

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfoIN IN
        {
            get
            {
                return this.inField;
            }
            set
            {
                this.inField = value;
            }
        }

        /// <remarks/>
        public string ResCountryCode
        {
            get
            {
                return this.resCountryCodeField;
            }
            set
            {
                this.resCountryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationHolderInfoIN
    {

        private string issuedByField;

        private string iNTypeField;

        private ulong valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string issuedBy
        {
            get
            {
                return this.issuedByField;
            }
            set
            {
                this.issuedByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string INType
        {
            get
            {
                return this.iNTypeField;
            }
            set
            {
                this.iNTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ulong Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPerson
    {

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPerson personField;

        private string ctrlgPersonTypeField;

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPerson Person
        {
            get
            {
                return this.personField;
            }
            set
            {
                this.personField = value;
            }
        }

        /// <remarks/>
        public string CtrlgPersonType
        {
            get
            {
                return this.ctrlgPersonTypeField;
            }
            set
            {
                this.ctrlgPersonTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPerson
    {

        private string firstNameField;

        private string lastNameField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonAddress addressField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonHolderTaxInfo holderTaxInfoField;

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonHolderTaxInfo HolderTaxInfo
        {
            get
            {
                return this.holderTaxInfoField;
            }
            set
            {
                this.holderTaxInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonAddress
    {

        private string cityField;

        private string countryCodeField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataOrganisationControllingPersonPersonHolderTaxInfo
    {

        private string resCountryCodeField;

        /// <remarks/>
        public string ResCountryCode
        {
            get
            {
                return this.resCountryCodeField;
            }
            set
            {
                this.resCountryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPerson
    {

        private string firstNameField;

        private string lastNameField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonAddress addressField;

        private AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonHolderTaxInfo holderTaxInfoField;

        /// <remarks/>
        public string FirstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string LastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonHolderTaxInfo HolderTaxInfo
        {
            get
            {
                return this.holderTaxInfoField;
            }
            set
            {
                this.holderTaxInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonAddress
    {

        private string cityField;

        private string countryCodeField;

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://hmrc.gov.uk/AEOIUKSubmissionFIReport")]
    public partial class AEOIUKSubmissionFIReportSubmissionFIReturnAccountDataPersonHolderTaxInfo
    {

        private string resCountryCodeField;

        /// <remarks/>
        public string ResCountryCode
        {
            get
            {
                return this.resCountryCodeField;
            }
            set
            {
                this.resCountryCodeField = value;
            }
        }
    }


}
