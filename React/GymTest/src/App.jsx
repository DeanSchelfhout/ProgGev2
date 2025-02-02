import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const App = () => {
  const [data, setData] = useState([]);
  const [filteredData, setFilteredData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    fetch("https://localhost:7082/api/Member")
      .then((response) => response.json())
      .then((data) => {
        setData(data);
        setFilteredData(data);
      })
      .catch((error) => console.error(error));
  }, []);

  const transformMemberType = (type) => {
    switch (type) {
      case 0:
        return "Bronze";
      case 1:
        return "Silver";
      case 2:
        return "Gold";
      default:
        return "Unknown";
    }
  };

  const handleNavigate = (memberId) => {
    navigate(`/reservation/${memberId}`);
  };

  const handleSearch = (event) => {
    const value = event.target.value;
    setSearchTerm(value);

    const filtered = data.filter(
      (item) =>
        item.firstName.toLowerCase().includes(value.toLowerCase()) ||
        item.lastName.toLowerCase().includes(value.toLowerCase())
    );

    setFilteredData(filtered);
  };

  return (
    <div>
      <h1>Members</h1>
      <input
        type="text"
        placeholder="Search by first or last name"
        value={searchTerm}
        onChange={handleSearch}
        style={{
          marginBottom: '20px',
          padding: '10px',
          width: '100%',
          boxSizing: 'border-box',
        }}
      />
      <table style={{ width: '100%', borderCollapse: 'collapse', margin: '20px 0' }}>
        <thead>
          <tr>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>First Name</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Last Name</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Address</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Birthday</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Email</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Interests</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Member Type</th>
            <th style={{ border: '1px solid #ddd', padding: '8px' }}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredData.map((item, index) => (
            <tr key={index} style={{ textAlign: 'left', borderBottom: '1px solid #ddd' }}>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.firstName}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.lastName}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.address}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.birthday}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.email}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{item.interests.join(', ')}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>{transformMemberType(item.memberType)}</td>
              <td style={{ border: '1px solid #ddd', padding: '8px' }}>
                <button
                  onClick={() => handleNavigate(item.memberId)}
                  style={{
                    padding: '5px 10px',
                    backgroundColor: '#007BFF',
                    color: '#fff',
                    border: 'none',
                    borderRadius: '4px',
                    cursor: 'pointer',
                  }}
                >
                  Make Reservation
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default App;
