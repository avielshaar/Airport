import React, { useState, useEffect } from 'react';
import { getData } from '../Services/dataService';
import { run } from '../Services/apiService';
import TableComponent from './TableComponent';
import StationsComponent from './StationsComponent';
import './AirportComponent.css';

const AirportComponent = () => {
    const [data, setData] = useState([]);
    const [isSimulating, setIsSimulating] = useState(false);
    const [isLoading, setIsLoading] = useState(true);
  
    useEffect(() => {
        const fetchData = async () => {
            const newData = await getData();
            setData(newData);
            setIsLoading(false);
        };
    
        const simulate = async () => {
          await run();
          fetchData();
        };
    
        fetchData(); 
        let interval;

        if (isSimulating) {
          interval = setInterval(simulate, 3000);
        }

        return () => {
          clearInterval(interval);
        };
      }, [isSimulating]);
    
      const toggleSimulation = () => {
        setIsSimulating(!isSimulating);
      };
  
    return (
      <div className="airport-container">
        <button onClick={toggleSimulation}  className="simulation-button">
          {isSimulating ? 'Stop' : 'Start'}
        </button>
        {isLoading ? (
          <p>Loading...</p>
        ) : (
          <>
          <div className='stations-component-container'>
            <StationsComponent data={data} />
          </div>
          <div className='table-component-container'>
            <TableComponent data={data} />
          </div>
            
          </>
        )}
      </div>
    );
};

export default AirportComponent;
