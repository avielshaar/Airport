import React, { useState, useEffect } from 'react';
import './TableComponent.css';

const TableComponent = ({ data }) => {
    const [arrivels, setArrivels] = useState([]);
    const [departures, setDepartures] = useState([]);

    useEffect(() => {
        if (data && data.length >= 2) {
          setArrivels(data[0]);
            setDepartures(data[1]);
        }
    }, [data]);

    return (
        <div className="table-container">
            <table>
                <thead>
                    <tr>
                        <th>Arrivels</th>
                        <th>Departures</th>
                    </tr>
                </thead>
                <tbody>
                    {Math.max(arrivels.length, departures.length) > 0 &&
                        Array.from({ length: Math.max(arrivels.length, departures.length) }).map((_, index) => (
                            <tr key={`row-${index}`}>
                                <td>{arrivels[index]}</td>
                                <td>{departures[index]}</td>
                            </tr>
                        ))}
                </tbody>
            </table>
        </div>
    );
};

export default TableComponent;
