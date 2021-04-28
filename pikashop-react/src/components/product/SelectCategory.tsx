import React from "react";
import ICategory from "../../interface/ICategory";
import { Input } from 'reactstrap';
import GetList from "../../services/GetList";

export default function Categories({ onChange, itemSelected }: any) {

    const [cates, setCates] = React.useState([]);
    const [cateSelected, setSelected] = React.useState(0);

    const _fetchCategoryData = () => {
        GetList("category")
            .then(res => {
                const cates = res.data;
                setCates(cates)
                console.log(cates);
            }).catch(err => {
                console.log(err);
            })
    }

    React.useEffect(() => {
        _fetchCategoryData();
    }, [])

    React.useEffect(() => {
        setSelected(itemSelected)
    }, [itemSelected])

    return (
        <>
            <Input type="select" value={cateSelected} name="id_category" onChange={onChange}>
                {cates.map((cates: ICategory) => (
                    <option key={+cates.id_category} value={cates.id_category}>
                        {cates.name_category}
                    </option>
                ))}
            </Input>
        </>
    )
}
