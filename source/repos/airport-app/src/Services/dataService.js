import {get} from './apiService'

export const getArrivels = (data) => {
    return data.filter(plane => plane.type === false).map(plane => plane['id']);
}

export const getDepartures = (data) => {
    return data.filter(plane => plane.type === true).map(plane => plane['id']);
}

export const getStations = (data) => {
    const stations = [
        { id: 1, planeId: null },
        { id: 2, planeId: null },
        { id: 3, planeId: null },
        { id: 4, planeId: null },
        { id: 5, planeId: null },
        { id: 6, planeId: null },
        { id: 7, planeId: null },
        { id: 8, planeId: null },
    ]
    data.forEach(plane => {
        stations.find(s => s.id === plane.stationId).planeId = plane.id
    });
    return stations.map(station => station['planeId'])
}

export const getData = async () => {
    const data = await get()
    return [getArrivels(data), getDepartures(data), getStations(data)]
}