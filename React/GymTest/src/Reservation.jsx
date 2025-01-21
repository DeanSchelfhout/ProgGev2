import { useState,useEffect } from 'react';
import { useParams } from 'react-router-dom';

function Reservation() {
  const { id } = useParams();
  const [date, setDate] = useState('');
  const [timeslot1, setTimeslot1] = useState('');
  const [equipment1, setEquipment1] = useState('');
  const [timeslot2, setTimeslot2] = useState('');
  const [equipment2, setEquipment2] = useState('');
  const [timeslot3, setTimeslot3] = useState('');
  const [equipment3, setEquipment3] = useState('');
  const [timeslot4, setTimeslot4] = useState('');
  const [equipment4, setEquipment4] = useState('');
  const [message, setMessage] = useState('');
  const [messageStyle, setMessageStyle] = useState(0);

  const [data, setData] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7082/api/Equipment")
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch((error) => console.error(error));
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();
  
    if (date) {
      const reservationData = {
        "EquipmentId1": equipment1|| '0',
        "TimeSlotId1": timeslot1|| '0',
        "EquipmentId2": equipment2|| '0',
        "TimeSlotId2": timeslot2|| '0',
        "EquipmentId3": equipment3|| '0',
        "TimeSlotId3": timeslot3|| '0',
        "EquipmentId4": equipment4|| '0',
        "TimeSlotId4": timeslot4|| '0',
        date,
        "MemberId": id
      };
      
      fetch("https://localhost:7082/api/Reservation", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservationData),
      })
        .then((response) => response.json())
        .then((data) => {
          if (data.message) {
            setMessage(data.message);
            setMessageStyle(1);
          } else {
            setMessage('An error occurred while making the reservation.');
            setMessageStyle(1);
          }
        })
        .catch(() => {
          setMessage('Reservation successfully made!');
            setMessageStyle(0);
        });
    } else {
      setMessage('Please select a date.');
      setMessageStyle(1);
    }
  };
  
  
  

  return (
    <div className="reservation-container">
      <h2>Reservering Formulier</h2>
      <form onSubmit={handleSubmit} className="reservation-form">
        <div className="form-group">
          <label htmlFor="date">Select a Date:</label>
          <input
            type="date"
            id="date"
            value={date}
            onChange={(e) => setDate(e.target.value)}
            required
          />
        </div>
  
        <div className="form-group">
          <label htmlFor="timeslot">Select Timeslots:</label>
          <select
            id="timeslot"
            value={timeslot1}
            onChange={(e) => setTimeslot1(e.target.value)}
          >
            <option value="">Select a Timeslot</option>
            <option value="1">08:00 - 09:00</option>
            <option value="2">09:00 - 10:00</option>
            <option value="3">10:00 - 11:00</option>
            <option value="4">11:00 - 12:00</option>
            <option value="5">12:00 - 13:00</option>
            <option value="6">13:00 - 14:00</option>
            <option value="7">14:00 - 15:00</option>
            <option value="8">15:00 - 16:00</option>
            <option value="9">16:00 - 17:00</option>
            <option value="10">17:00 - 18:00</option>
            <option value="11">18:00 - 19:00</option>
            <option value="12">19:00 - 20:00</option>
            <option value="13">20:00 - 21:00</option>
            <option value="14">21:00 - 22:00</option>
          </select>
          <select
            id="timeslot"
            value={timeslot2}
            onChange={(e) => setTimeslot2(e.target.value)}
          >
            <option value="">Select a Timeslot</option>
            <option value="1">08:00 - 09:00</option>
            <option value="2">09:00 - 10:00</option>
            <option value="3">10:00 - 11:00</option>
            <option value="4">11:00 - 12:00</option>
            <option value="5">12:00 - 13:00</option>
            <option value="6">13:00 - 14:00</option>
            <option value="7">14:00 - 15:00</option>
            <option value="8">15:00 - 16:00</option>
            <option value="9">16:00 - 17:00</option>
            <option value="10">17:00 - 18:00</option>
            <option value="11">18:00 - 19:00</option>
            <option value="12">19:00 - 20:00</option>
            <option value="13">20:00 - 21:00</option>
            <option value="14">21:00 - 22:00</option>
          </select>
          <select
            id="timeslot"
            value={timeslot3}
            onChange={(e) => setTimeslot3(e.target.value)}
          >
            <option value="">Select a Timeslot</option>
            <option value="1">08:00 - 09:00</option>
            <option value="2">09:00 - 10:00</option>
            <option value="3">10:00 - 11:00</option>
            <option value="4">11:00 - 12:00</option>
            <option value="5">12:00 - 13:00</option>
            <option value="6">13:00 - 14:00</option>
            <option value="7">14:00 - 15:00</option>
            <option value="8">15:00 - 16:00</option>
            <option value="9">16:00 - 17:00</option>
            <option value="10">17:00 - 18:00</option>
            <option value="11">18:00 - 19:00</option>
            <option value="12">19:00 - 20:00</option>
            <option value="13">20:00 - 21:00</option>
            <option value="14">21:00 - 22:00</option>
          </select>
          <select
            id="timeslot"
            value={timeslot4}
            onChange={(e) => setTimeslot4(e.target.value)}
          >
            <option value="">Select a Timeslot</option>
            <option value="1">08:00 - 09:00</option>
            <option value="2">09:00 - 10:00</option>
            <option value="3">10:00 - 11:00</option>
            <option value="4">11:00 - 12:00</option>
            <option value="5">12:00 - 13:00</option>
            <option value="6">13:00 - 14:00</option>
            <option value="7">14:00 - 15:00</option>
            <option value="8">15:00 - 16:00</option>
            <option value="9">16:00 - 17:00</option>
            <option value="10">17:00 - 18:00</option>
            <option value="11">18:00 - 19:00</option>
            <option value="12">19:00 - 20:00</option>
            <option value="13">20:00 - 21:00</option>
            <option value="14">21:00 - 22:00</option>
          </select>
        </div>
  
        <div className="form-group">
          <label htmlFor="equipment">Select Equipment:</label>
          <select
            id="equipment"
            value={equipment1}
            onChange={(e) => setEquipment1(e.target.value)}
          >
            <option value="">Select Equipment</option>
            {data.map((item, index) => (
                <option key={index} value={item.equipmentId}>{item.deviceType}</option>
            ))}
          </select>
          <select
            id="equipment"
            value={equipment2}
            onChange={(e) => setEquipment2(e.target.value)}
          >
            <option value="">Select Equipment</option>
            {data.map((item, index) => (
                <option key={index} value={item.equipmentId}>{item.deviceType}</option>
            ))}
          </select>
          <select
            id="equipment"
            value={equipment3}
            onChange={(e) => setEquipment3(e.target.value)}
          >
            <option value="">Select Equipment</option>
            {data.map((item, index) => (
                <option key={index} value={item.equipmentId}>{item.deviceType}</option>
            ))}
          </select>
          <select
            id="equipment"
            value={equipment4}
            onChange={(e) => setEquipment4(e.target.value)}
          >
            <option value="">Select Equipment</option>
            {data.map((item, index) => (
                <option key={index} value={item.equipmentId}>{item.deviceType}</option>
            ))}
          </select>
        </div>
  
        <button type="submit" className="submit-btn">Reserveren</button>
      </form>
  
      {message && (
        <p className={`message ${messageStyle === 1 ? 'error' : 'success'}`}>
          {message}
        </p>
      )}
  
      <style>{`
        .reservation-container {
          font-family: Arial, sans-serif;
          padding: 20px;
          background-color: #f4f4f4;
          border-radius: 8px;
          max-width: 400px;
          margin: auto;
        }
  
        h2 {
          text-align: center;
          color: #333;
        }
  
        .reservation-form {
          display: flex;
          flex-direction: column;
          gap: 15px;
        }
  
        .form-group {
          display: flex;
          flex-direction: column;
        }
  
        label {
          margin-bottom: 5px;
          font-weight: bold;
          color: #333;
        }
  
        input, select {
          padding: 10px;
          border: 1px solid #ccc;
          border-radius: 4px;
          font-size: 14px;
        }
  
        button.submit-btn {
          padding: 10px;
          background-color: #4CAF50;
          color: white;
          border: none;
          border-radius: 4px;
          cursor: pointer;
          font-size: 16px;
          font-weight: bold;
        }
  
        button.submit-btn:hover {
          background-color: #45a049;
        }
  
        .message {
          text-align: center;
          font-size: 16px;
          font-weight: bold;
          margin-top: 20px;
        }
  
        .message.success {
          color: green;
        }
  
        .message.error {
          color: red;
        }
      `}</style>
    </div>
  );    
}

export default Reservation;
