using AutoMapper;
using DataAccessLayer.Repository;
using DTO;
using DTO.ApiDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GameController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _unitOfWork.Games.GetAll().ToList();
            var itemsDTO = _mapper.Map<List<GameDto>>(items);
            return Ok(itemsDTO);
        }

        [HttpPost]
        public IActionResult Post(GameDto itemDTO)
        {
            var item = _mapper.Map<Game>(itemDTO);
            _unitOfWork.Games.Add(item);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _unitOfWork.Games.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemDTO = _mapper.Map<GameDto>(item);
            return Ok(itemDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, GameDto itemDTO)
        {
            var item = _unitOfWork.Games.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            _mapper.Map(itemDTO, item);
            _unitOfWork.Games.Update(item);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _unitOfWork.Games.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            _unitOfWork.Games.Delete(item);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("unapproved")]
        public IActionResult GetUnapproved()
        {
            var items = _unitOfWork.Games.GetUnapprovedItems();
            var itemsDTO = _mapper.Map<List<GameDto>>(items);
            return Ok(itemsDTO);
        }

    }
}
