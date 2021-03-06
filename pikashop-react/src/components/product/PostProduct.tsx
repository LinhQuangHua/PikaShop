import React, { useState } from "react";
import { Col, Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Edit from "../../services/Edit";
import Create from "../../services/Create";
import SelectBrand from "./SelectBrand";
import SelectCategory from "./SelectCategory";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default ({ itemEdit, onChange }: any) => {
    const [namePro, setName] = useState(
        { name_product: '', image: '', ThumbnailImage: '', price: null, height: null, weight: null, description: '', quantity: null, id_brand: 1, id_category: 1 } as any
    );

    React.useEffect(() => {
        if (itemEdit != null) setName(itemEdit)
        console.log(itemEdit);
    }, [itemEdit])

    const handleChange = (event: any) => {

        const { name, value } = event.target

        if (name === "ThumbnailImage") {

            setName({ ...namePro, ThumbnailImage: event.target.files[0], image: event.target.files[0] })
        }
        else {
            setName({
                ...namePro,
                [name]: value,
            })
        }
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        var postData = new FormData();

        Object.keys(namePro).forEach(function (key) {
            postData.append(key, namePro[key]);
        });
        if (itemEdit == null) {
            Create("product", postData)
                .then(res => {
                    console.log(postData);
                    toast.success(`Add a new product is ${namePro.name_product} Success notification`, { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                    onChange();
                }).catch(err => {
                    console.log(err);
                    toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                })
        }
        else {
            Edit("product", itemEdit.id_product, postData)
                .then(res => {
                    console.log({ ...postData });
                    onChange();
                    toast.success(`Edit a product has Id is ${itemEdit.id_product} Success notification`, { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                }).catch(err => {
                    console.log(err);
                    toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                })
        }

    }
    return (
        <>
            <br />
            <h5 style={{ color: "#000000" }}>Add new product</h5>
            <Form inline onSubmit={handleSubmit} style={{ color: "#000000" }}>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Name</Label>
                        <Input type="text" value={namePro.name_product} name="name_product" placeholder="Name product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Price</Label>
                        <Input type="number" value={namePro.price} name="price" placeholder="Price product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Height</Label>
                        <Input type="number" value={namePro.height} name="height" placeholder="Height product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Weight</Label>
                        <Input type="number" value={namePro.weight} name="weight" placeholder="Weight product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={4}>Quantity</Label>
                        <Input type="number" value={namePro.quantity} name="quantity" placeholder="Quantity product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col sm={10}>
                        <Label sm={3}>Brand</Label>
                        <SelectBrand itemSelected={namePro.id_brand} onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={4}>Category</Label>
                        <SelectCategory itemSelected={namePro.id_category} onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col sm={10}>
                        <Label sm={3}>Description</Label>
                        <Input type="textarea" value={namePro.description} rows="4" cols="50" name="description" placeholder="Description product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label>Image</Label>
                        <Input type="file" name="ThumbnailImage" onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Button type="submit" color="success" style={{ width: 100 }}>{itemEdit ? "Save" : "Add"}</Button>
                        <ToastContainer />
                    </Col>
                </FormGroup>
            </Form>
            <hr />
        </>
    )
}