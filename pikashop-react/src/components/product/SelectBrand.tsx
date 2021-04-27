import React from "react";
import IBrand from "../../interface/IBrand";
import { Input } from 'reactstrap';
import GetList from "../../services/GetList";

export default function Brands(props: any) {

    const [cates, setCates] = React.useState([]);
    const [cateSelected, setSelected] = React.useState(0);

    const _fetchBrandData = () => {
        GetList("brands")
            .then(res => {
                const cates = res.data;
                setCates(cates)
                console.log(cates);
            }).catch(err => {
                console.log(err);
            })
    }

    React.useEffect(() => {
        _fetchBrandData();
    }, [])

    React.useEffect(() => {
        setSelected(props.itemSelected)
    }, [props.itemSelected])

    const handleChange = (event: any) => {
        let val = event.target.value;
        setSelected(val);
    }

    return (
        <>
            <Input type="select" value={cateSelected} name="cates.Name" onChange={handleChange}>
                {cates.map((cates: IBrand) => (
                    <option key={+cates.Id} value={cates.Id}>
                        {cates.Name}
                    </option>
                ))}
            </Input>
        </>
    )
}
