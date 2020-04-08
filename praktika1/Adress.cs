using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace praktika1
{
    class Adress
    {
        [Required, RegularExpression("/^[A-Za-z]+$/")]
        public string surname { get; }
        [Required, RegularExpression(@"/^[a-zA-Zs]*$/")]
        public string streetName { get; }
        [Required, RegularExpression("/^[0-9A-Z]+$/")]
        public string buildingNum { get; }
        [Required, RangeAttribute(0, 200)]
        public string floorNum { get; }
        [Required, RangeAttribute(0, 9999)]
        public string roomNum { get; }
        public Adress(string _surname, string _streetName, string _buildingNum, string _floorNum, string _roomNum)
        {
            surname = _surname;
            streetName = _streetName;
            buildingNum = _buildingNum;
            floorNum = _floorNum;
            roomNum = _roomNum;
            if (string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(streetName) || string.IsNullOrWhiteSpace(buildingNum) || string.IsNullOrWhiteSpace(floorNum) || string.IsNullOrWhiteSpace(roomNum))
                throw new ValidationException("Slavik");
        }
    }
}
