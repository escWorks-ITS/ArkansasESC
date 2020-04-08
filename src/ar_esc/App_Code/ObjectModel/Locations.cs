using System;
using System.Collections.Generic;
using System.Text;


namespace escWeb.ar_esc.ObjectModel
{
    [Serializable]
    public class Site : region4.ObjectModel.Site
    {
        public Site(int obj_id) : base(obj_id)
        { 
        }

    }

    [Serializable]
    public class Room : region4.ObjectModel.Room
    {
        public Room(int obj_id) : base(obj_id)
        {
        }
       
    }

    [Serializable]
    public class Organization : region4.ObjectModel.Organization
    {
        public Organization(int obj_id) : base(obj_id)
        {
        }

        //protected override bool IsEntityOrganization
        //{
        //    get { throw new Exception("The method or operation is not implemented."); }
        //}
    }


}