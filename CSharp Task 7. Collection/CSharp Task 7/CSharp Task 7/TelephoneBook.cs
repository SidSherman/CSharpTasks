using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace CSharpTask7
{
    class TelephoneBook
    {
        private List<TelephoneContact> telephoneContacts = new List<TelephoneContact>();

        public List<TelephoneContact> TelephoneContacts { get => telephoneContacts; set => telephoneContacts = value; }

        public TelephoneBook()
        { }

        public TelephoneBook(TelephoneContact contact)
        {
            AddContact(contact);
        }

        TelephoneBook(List<TelephoneContact> telephoneContacts)
        {
            TelephoneContacts = telephoneContacts;
        }

        public void AddContact(TelephoneContact contact)
        {
            TelephoneContacts.Add(contact);
        }

        public void AddContact(string name, string street, string houseName, string flatNumber, string mobilePhone, string flatPhone)
        {
            TelephoneContacts.Add(new TelephoneContact(name, street, houseName, flatNumber, mobilePhone, flatPhone));
        }

        public string SerializeAllDataToXML()
        {
            string str = "";
            foreach (TelephoneContact contact in TelephoneContacts)
            {
                str += SerializeDataToXML(contact);
            }

            return str;
        }

        public string SerializeDataToXML(TelephoneContact contact)
        {
            XElement xmlPerson = new XElement("Person");
            XElement xmlAddress = new XElement("Adress");
            XElement xmlStreet = new XElement("Street");
            XElement xmlPhones = new XElement("Phones");
            XElement xmlHouseNumber = new XElement("HouseNumber");
            XElement xmlFlatNumber = new XElement("FlatNumber");
            XElement xmlMobilePhone = new XElement("MobilePhone");
            XElement xmlFlatPhone = new XElement("FlatPhone");

            XAttribute xmlNameAttr = new XAttribute("name", contact.Name);

            xmlPerson.Add(xmlNameAttr);
            xmlStreet.Add(contact.Street);
            xmlFlatNumber.Add(contact.FlatNumber);
            xmlHouseNumber.Add(contact.HouseNumber);
            xmlMobilePhone.Add(contact.MobilePhone);
            xmlFlatPhone.Add(contact.FlatPhone);

            xmlAddress.Add(xmlStreet, xmlHouseNumber, xmlFlatNumber);
            xmlPhones.Add(xmlMobilePhone, xmlFlatPhone);
            xmlPerson.Add(xmlAddress, xmlPhones);

            return xmlPerson.ToString();

        }

        public void ClearData()
        {
            TelephoneContacts.Clear();
        }
    }

    class TelephoneContact
    {

        private string name;
        private string street;
        private string houseNumber;
        private string flatNumber;
        private string mobilePhone;
        private string flatPhone;

        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }
        public string MobilePhone { get => mobilePhone; set => mobilePhone = value; }
        public string FlatPhone { get => flatPhone; set => flatPhone = value; }

        public TelephoneContact()
        {

        }

        public TelephoneContact(string name, string street, string houseName, string flatNumber, string mobilePhone, string flatPhone)
        {
            Name = name;
            Street = street;
            HouseNumber = houseName;
            FlatNumber = flatNumber;
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }
    }


}
