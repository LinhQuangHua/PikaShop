import axios from 'axios';
import { store } from '../store/store';
import { hostURL } from "../config";

export default function GetList(pathSer: string) {

    var user = store.getState().auth.user;
    console.log(pathSer);
    return axios.get(
        `${hostURL}/api/${pathSer}`,
        {
            headers: { "Authorization": `Bearer ${user?.token}` },
        })
}
