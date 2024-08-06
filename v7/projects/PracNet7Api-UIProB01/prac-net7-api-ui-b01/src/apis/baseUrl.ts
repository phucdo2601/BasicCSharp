import axios from "axios";

export const ROOT_BASE_URL = "https://localhost:7091/";

export const basicCalApi = () => {
    const instance = axios.create({
        baseURL: ROOT_BASE_URL +"api/",
        headers: {
            'Content-Type': 'application/json'
        }
    });

    return instance;
}