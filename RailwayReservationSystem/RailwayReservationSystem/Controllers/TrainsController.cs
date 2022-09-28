using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayReservationSystem.Data;
using RailwayReservationSystem.Models;

namespace RailwayReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly RailwayDbContext _context;

        public TrainsController(RailwayDbContext context)
        {
            _context = context;
        }

        // GET: api/Trains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetTrains()
        {
            return await _context.Trains.ToListAsync();
        }

        // GET: api/Trains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetTrain(int id)
        {
            var train = await _context.Trains.FindAsync(id);

            if (train == null)
            {
                return NotFound();
            }

            return train;
        }

        // PUT: api/Trains/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateTrain")]
        public async Task<IActionResult> PutTrain(TrainDtoput trainDtoput)
        {
            Train train = _context.Trains.FirstOrDefault(tr => tr.TrainId == trainDtoput.TrainId);

            train.TrainId = trainDtoput.TrainId;
            train.TrainNo = trainDtoput.TrainNo;
            train.TrainName = trainDtoput.TrainName;
            train.SourceStation = trainDtoput.SourceStation;
            train.DestinationStation = trainDtoput.DestinationStation;
            train.SourceDepartureTime = trainDtoput.SourceDepartureTime;
            train.DestinationArrivalTime = trainDtoput.DestinationArrivalTime;
            train.TotalSeat = trainDtoput.TotalSeat;
            train.AvailableGeneralSeat = trainDtoput.AvailableLadiesSeat;
            train.AvailableLadiesSeat = trainDtoput.AvailableLadiesSeat;
            train.SeatFare = trainDtoput.SeatFare;


            _context.Entry(train).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainExists(trainDtoput.TrainId))
                {
                    return NotFound();
                }
                
                
                   
                

            }
            return Ok(train);
        }

        // POST: api/Trains
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Train>> PostTrain(TrainDto trainDto)
        {
            var _trainDto = new Train()
            {
                TrainNo = trainDto.TrainNo,
                TrainName = trainDto.TrainName,
                SourceStation = trainDto.SourceStation,
                DestinationStation = trainDto.DestinationStation,
                SourceDepartureTime = trainDto.SourceDepartureTime,
                DestinationArrivalTime = trainDto.DestinationArrivalTime,
                TotalSeat = trainDto.TotalSeat,
                AvailableGeneralSeat = trainDto.AvailableGeneralSeat,
                AvailableLadiesSeat = trainDto.AvailableLadiesSeat,
                SeatFare = trainDto.SeatFare

            };
            _context.Trains.Add(_trainDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrain", new { id = _trainDto }, _trainDto);
        }

        
        private bool TrainExists(int id)
        {
            return _context.Trains.Any(e => e.TrainId == id);
        }
    }
}
