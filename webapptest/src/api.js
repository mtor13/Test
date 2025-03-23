import axios from "axios";

const API_URL = "http://localhost:5299/"; 
export const postUser = async (data) => {
  const response = await axios.post(API_URL+'AddUsuario', data);
  return response.data;
};

export const getActividades = async () => {
  const response = await axios.get(API_URL+'GetActividades');
  return response.data;
};
