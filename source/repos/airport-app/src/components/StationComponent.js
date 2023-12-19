import React from 'react';
import './StationComponent.css';

const StationComponent = ({ top, left, stationId, planeId }) => {
  const stationStyle = {
    top: `${top}px`,
    left: `${left}px`,
  };

  return (
    <div className="station-container" style={stationStyle}>
      <img src={process.env.PUBLIC_URL + '/station.png'} alt="" className="station"/>
      <div className="station-id">{stationId}</div>
      {planeId && (
        <div className="plane-container">
          <img src={process.env.PUBLIC_URL + '/plane.png'} alt="" className="plane"/>
          {<div className="plane-id">{planeId}</div>}
        </div>
      )}
    </div>
  );
};

export default StationComponent;
