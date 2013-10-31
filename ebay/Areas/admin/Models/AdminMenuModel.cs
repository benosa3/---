using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoRepository;
//using System.Data.Entity;

namespace ebay.Areas.admin.Models
{
    public class AdminMenuModel : Entity
    {
        public int IdMenu{set;get;}
        public string Action { set; get; }
        public string Name { set; get; }
        public List<AdminMenuModel> SubMenu { set; get; }
        /*public AdminMenuModel SubMenu {
            set
            {

            }            
            get {
                try{
                    Helpers.DbContext<AdminMenuModel>.Current.ToList();
                }
                catch(Exception e){
                    string s = e.Message;
                }
                return new AdminMenuModel(); 
            }
            //set { _seconds = value; }
        }*/
        

    }
}