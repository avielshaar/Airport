import axios from 'axios';

export const get = async () => {
const response = await axios.get('https://localhost:7021/api/Airport/Get');
return response.data;
};

export const run = async () => {
await axios.post('https://localhost:7021/api/Airport/Run');
};
