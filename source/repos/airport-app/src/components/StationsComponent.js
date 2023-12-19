import React, { useState, useEffect } from 'react';
import StationComponent from './StationComponent';

const StationsComponent = ({ data }) => {
    const [stations, setStations] = useState(data[2]);

    useEffect(() => {
      setStations(data[2]);
    }, [data]);

    return (
        <div className="stations-container">
            <StationComponent top={50} left={1150} stationId={1} planeId={stations[0]}/>
            <StationComponent top={50} left={800} stationId={2} planeId={stations[1]}/>
            <StationComponent top={50} left={450} stationId={3} planeId={stations[2]}/>
            <StationComponent top={50} left={100} stationId={4} planeId={stations[3]}/>
            <StationComponent top={250} left={100} stationId={5} planeId={stations[4]}/>
            <StationComponent top={450} left={100} stationId={6} planeId={stations[5]}/>
            <StationComponent top={450} left={450} stationId={7} planeId={stations[6]}/>
            <StationComponent top={250} left={450} stationId={8} planeId={stations[7]}/>
        </div>
    );
};

export default StationsComponent;
