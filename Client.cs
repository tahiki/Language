//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ClientService = new HashSet<ClientService>();
            this.Tag = new HashSet<Tag>();
        }
    
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string GenderCode { get; set; }
        public string Phone { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public System.DateTime RegistrationDate { get; set; }

        public string VisitDate
        {
            get
            {
                if (this.VisitCount == 0)
                    return "Нет";
                else
                {
                    return ClientService.Max(p => p.StartTime).ToShortDateString();
                }
            }
        }

        public int VisitCount
        {
            get
            {
                var datelist = ClientService.Where(p => p.ClientID == this.ID).ToList();
                return datelist.Count;
            }
        }
        public string GenderName
        {
            get { return Gender.Name; }
        }
        public string BirthdayString
        {
            get
            {
                if (Birthday != null)
                {
                    return Birthday.Value.ToShortDateString();
                }
                else
                    return "";
            }
        }

        public Client Clone()
        {
            return new Client
            {
                ID = this.ID,
                LastName = this.LastName,
                FirstName = this.FirstName,
                Patronymic = this.Patronymic,
                GenderCode = this.GenderCode,
                Phone = this.Phone,
                PhotoPath = this.PhotoPath,
                Birthday = this.Birthday,
                Email = this.Email,
                RegistrationDate = this.RegistrationDate,
                Gender = this.Gender,
                ClientService = new System.Collections.Generic.HashSet<ClientService>(this.ClientService),
                Tag = new System.Collections.Generic.HashSet<Tag>(this.Tag)
            };
        }

        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tag { get; set; }
    }
}
