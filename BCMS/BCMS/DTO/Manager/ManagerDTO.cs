using System.ComponentModel.DataAnnotations;

namespace BCMS.DTO.Manager
{
    public class ManagerDTO
    {
        public string ManagerId { get; set; }
        public string ManagerUserName { get; set; }
        public string ManagerPhone { get; set; }
        public string ManagerPassword { get; set; }
        public string ManagerEmail { get; set; }
        public bool ManagerStatus { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerImage { get; set; }
    }
}
