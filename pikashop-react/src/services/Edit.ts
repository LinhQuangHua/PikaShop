import axios from 'axios';
import { store } from '../store/store';

export default function Edit(pathSer: string, params: any, data: any) {

    var user = store.getState().auth.user;
    console.log(pathSer + "/" + params);
    return axios.put(
        `https://pikashop.azurewebsites.net/api/${pathSer}/${params}`,
        data,
        {
            headers: { "Authorization": `Bearer ${user?.token}` },
        })
}