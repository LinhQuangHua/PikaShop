import axios from 'axios';
import { store } from '../store/store';
import { hostURL } from "../config";

export default function Delete(pathSer: string, params: any) {

    var user = store.getState().auth.user;
    console.log(pathSer + "/" + params);
    return axios.delete(
        `${hostURL}/api/${pathSer}/${params}`,
        {
            headers: { "Authorization": `Bearer ${user?.token}` },
        })
}
