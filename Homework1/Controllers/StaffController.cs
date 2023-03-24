using Homework1.Data.Model;
using Homework1.Data.UnitOfWork.Abstract;
using Homework1.Data.UnitOfWork.Concrete;
using Homework1.Web.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Web.Controllers;


[Route("homework1/api/v1.0/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public StaffController(IUnitOfWork _unitOfWork) {
        this._unitOfWork = _unitOfWork;
    }

    [HttpGet]
    public List<Staff> GetAll()
    {
        List<Staff>  staffList = _unitOfWork.StaffRepository.GetAll();

        return staffList;
        
    }

    [HttpGet("{id}")]
    public Staff GetById(int id)
    {
        Staff staff1 = _unitOfWork.StaffRepository.GetById(id);

        return staff1;
    }

    [HttpPost("/createStaff")]
    public IActionResult CreateStaff([FromBody] Staff request)
    {
        //validator create
        var staffValidator = new StaffValidator();


        // Call Validate or ValidateAsync and pass the object which needs to be validated
        var result = staffValidator.Validate(request);

        if (result.IsValid)
        {
            _unitOfWork.StaffRepository.Post(request);
            _unitOfWork.Complete();

            return Ok(request);
        }
       

        var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        return BadRequest(errorMessages);
    }

    [HttpDelete("{id}")]
    public void DeleteStaff(int id)
    {

        Staff staff = _unitOfWork.StaffRepository.GetById(id);
        _unitOfWork.StaffRepository.Delete(staff);
        _unitOfWork.Complete();

           
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Staff request)
    {

        //validator create
        var staffValidator = new StaffValidator();


        // Call Validate or ValidateAsync and pass the object which needs to be validated
        var result = staffValidator.Validate(request);

        if (result.IsValid)
        {
            request.Id = id;
            _unitOfWork.StaffRepository.Put(request);
            _unitOfWork.Complete();

            return Ok(request);
        }


        var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        return BadRequest(errorMessages);

       
    }

    
        [HttpGet("/filteredList")]
        public List<Staff> GetByFilter([FromQuery] String city, [FromQuery] String name)
        {
            List<Staff> filterList = _unitOfWork.GetByFilter(city,name);
            return filterList;
        }





}

