﻿namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    /// Instead of throwing exceptions, a suggestion is made to fix.
    /// Input Validation on UI side should fix the issues instead of a THROW
    public class Customers
    {
    
        public int CustomerID { get; set; }

        private string  _CFirstName;
        public string CFirstName
        {
            get { return  _CFirstName; }
            set {  _CFirstName = value; }
        }
        
        private string _CLastName;
        public string CLastName
        {
            get { return _CLastName; }
            set { _CLastName = value; }
        }
        

        private string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }

            set { _CustomerAddress = value; }
        }
        private string _CustomerCity;
        public string CustomerCity
        {
            get { return _CustomerCity; }

            set { _CustomerCity = value; }
        }
   
        private string _CustomerState;
        public string CustomerState
        {
            get { return _CustomerState; }

            set { _CustomerState = value;}
        }
        private string _CustomerZipcode;
        public string CustomerZipcode
        {
            get { return _CustomerZipcode; }

            set { _CustomerZipcode = value; }
        }

        private string _CustomerCountry;
        public string CustomerCountry
        {
            get { return _CustomerCountry; }

            set { _CustomerCountry = value; }
        }
        private string _CustomerEmail;

        public string CustomerEmail
        {
            get { return _CustomerEmail; }

            set { _CustomerEmail = value; }
        }
        private string _Password;
        public string CPassword
        {
            get { return _Password; }

            set { _Password = value; }
        }

        private bool _isAdmin;
        public bool isAdmin
        {
            get { return _isAdmin; }

            set { _isAdmin = value; }
        }
        

        //Default Class Constructor
        public Customers()
        {
            CFirstName ="";
            CLastName = "";
            CustomerAddress = "";
            CustomerState = "";
            CustomerCity = "";
            CustomerZipcode = "";
            CustomerCountry = "";
            CustomerEmail = "";
            CPassword = "";
            isAdmin = false;
        }

        public override string ToString()
        {
            return $"Customer Id: {CustomerID}\nFirst Name: {CFirstName}\nLast name: {CLastName}\n" +
            $"\nAddress: {CustomerAddress}\nCustomer State: {CustomerState}\nCustomer City: {CustomerCity}" +
            $"\nCustomer Country: {CustomerCountry}\nEmail: {CustomerEmail}";
        }
    }
}