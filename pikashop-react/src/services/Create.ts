import axios from 'axios';
import { store } from '../store/store';
import { hostURL } from "../config";

export default function Edit(pathSer: string, data: any) {

    var user = store.getState().auth.user;
    return axios.post(
        `${hostURL}/api/${pathSer}`,
        data,
        {
            headers: { "Authorization": `Bearer ${user?.token}` },
        })
}