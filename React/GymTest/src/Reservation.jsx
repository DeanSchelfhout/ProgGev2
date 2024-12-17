import { useState,useEffect } from 'react';
import { useParams } from 'react-router-dom';

function Reservation() {
  const { id } = useParams();
  const [date, setDate] = useState('');
  const [timeslot, setTimeslot] = useState('');
  const [equipment, setEquipment] = useState('');
  const [message, setMessage] = useState('');

  const [data, setData] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7082/api/Equipment/GetAll")
      .then((response) => response.json())
      .then((data) => setData(data))
      .catch((error) => console.error(error));
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();

    if (date && timeslot && equipment) {
      const reservationData = { "equipmentId":equipment, "timeslotId":timeslot, date, "memberId":id };

      fetch("https://localhost:7082/api/Reservation/Add", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(reservationData),
      })
        .then((response) => response.json())
        .then(() => setMessage("Reservation Made!"))
        .catch(() => setMessage('Error creating reservation.'));

    } else {
      setMessage('All fields are required.');
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
          <label htmlFor="timeslot">Select a Timeslot:</label>
          <select
            id="timeslot"
            value={timeslot}
            onChange={(e) => setTimeslot(e.target.value)}
            required
          >
            <option value="">Select a Timeslot</option>
            <option value="1">08:00 - 09:00</option>
            <option value="2">09:00 - 010:00</option>
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
            value={equipment}
            onChange={(e) => setEquipment(e.target.value)}
            required
          >
            <option value="">Select Equipment</option>
            {data.map((item, index) => (
                <option key={index} value={item.equipmentId}>{item.deviceType}</option>
            ))}
          </select>
        </div>

        <button type="submit" className="submit-btn">Reserveren</button>
      </form>

      {message && <p className="message">{message}</p>}
      
      <style jsx>{`
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
          color: green;
          font-size: 16px;
          font-weight: bold;
          margin-top: 20px;
        }
      `}</style>
    </div>
  );
}

export default Reservation;
