using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rantalDal)
        {
            _rentalDal = rantalDal;
        }

        public IResult Add(Rental rental)
        {
            List<Rental> rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (rentals.Count != 0)
            {
                Rental isRentalbe = rentals.SingleOrDefault(r => r.ReturnDate == null);
                if (isRentalbe == null)
                {
                    return new SuccessResult("araç kiralanabilir.");
                }
                else
                {
                    return new ErrorResult("Araç kiralanmış zaten");

                }
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araç kiralandı.");
        }
    }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("Kayıt silindi");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult("Kayıt güncellendi");
        }
    }
}
