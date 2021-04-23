import React, { useState } from "react";
import axios from 'axios';
import { Col, Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useSelector } from "react-redux";
import { selectUser } from "../../store/auth-slice";

export default () => {
    const [namePro, setName] = useState(
        { name_product: '', image: '', ThumbnailImage: '', price: 0, height: 0, weight: 0, description: '', quantity: 0, id_brand: 1, id_category: 1 } as any
    );

    const user = useSelector(selectUser);


    const handleChange = (event: any) => {
        const { name, value } = event.target

        if (name === "ThumbnailImage") {

            setName({ ...namePro, ThumbnailImage: event.target.files[0], image: event.target.files[0] })
        }
        else {
            setName({
                ...namePro,
                [name]: value
            })
        }

    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        var postData = new FormData();

        Object.keys(namePro).forEach(function (key) {
            postData.append(key, namePro[key]);
        });

        axios.post(
            `https://pikashop.azurewebsites.net/api/product`,
            postData,
            {
                headers: { "Authorization": `Bearer ${user?.token}` },
            }).then(res => {
                console.log(res.data);
            }).catch(err => {
                console.log(err);
            })
    }
    return (
        <>
            <br />
            <h5>Add new brand</h5>
            <Form inline onSubmit={handleSubmit}>
                <FormGroup row>
                    <Label sm={2}>Name</Label>
                    <Col sm={10}>
                        <Input type="text" value={namePro.name_product} name="name_product" placeholder="Name product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Image</Label>
                    <Col sm={10}>
                        <Input type="file"
                            name="ThumbnailImage" onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Price</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.price} name="price" placeholder="Price product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Height</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.height} name="height" placeholder="Height product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Weight</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.weight} name="weight" placeholder="Weight product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Description</Label>
                    <Col sm={10}>
                        <Input type="textarea" value={namePro.description} name="description" onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Quantity</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.quantity} name="quantity" placeholder="Quantity product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Brand</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.id_brand} name="id_brand" placeholder="Brand product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Label sm={2}>Category</Label>
                    <Col sm={10}>
                        <Input type="number" value={namePro.id_category} name="id_category" placeholder="Category product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup row>
                    <Col sm={50}>
                        <Button type="submit">Add</Button>
                    </Col>
                </FormGroup>
            </Form>
            <hr />
        </>
    )
}