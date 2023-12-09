import React, { useState, useEffect } from 'react';

const App = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch('https://localhost:7021/api/Airport');
      const jsonData = await response.json();
      setData(jsonData);
    };

    fetchData();
  }, []);

  return (
    <div>
      <h2>Airport Data</h2>
      <ul>
        {data.map((item) => (
          <li key={item.id}>
            ID: {item.id}, Station ID: {item.stationId}, Type: {item.type}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default App;
