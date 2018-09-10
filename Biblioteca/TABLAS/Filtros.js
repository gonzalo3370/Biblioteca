import React from 'react';
import { Picker, Button, FlatList, StyleSheet, Text, View } from 'react-native';

export default class App extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            Generos: [],
            itemSeleccionado: 1,            
            Autores: [],
            itemSeleccionado2: 1,
            Estados: [],
            itemSeleccionado3: 1,
            Libros: []
        }
    }
    componentDidMount = () =>{
        this.GetGeneros();
        this.GetAutores();
        this.GetEstados();
    };
    GetGeneros = () => {
        fetch('http://192.168.0.97/api/Consultas/GetGeneros')
        .then((response) => response.json())
        .then((responseJson)=>{
            this.setState({
                Generos:responseJson
            }, function(){});            
        })
        .catch((error)=>{
            console.error(error);            
        });
    };
    GetAutores = () => {
        fetch('http://192.168.0.97/api/Consultas/GetAutores')
        .then((response) => response.json())
        .then((responseJson)=>{
            this.setState({
                Autores:responseJson
            }, function(){});            
        })
        .catch((error)=>{
            console.error(error);            
        });
    };
    GetEstados = () => {
        fetch('http://192.168.0.97/api/Consultas/GetEstados')
        .then((response) => response.json())
        .then((responseJson)=>{
            this.setState({
                Estados:responseJson
            }, function(){});            
        })
        .catch((error)=>{
            console.error(error);            
        });
    };
    onSelecciono = (itemValue)=>{
        this.setState({
            itemSeleccionado: itemValue
        })
    }
    onSelecciono2 = (itemValue)=>{
        this.setState({
            itemSeleccionado2: itemValue
        })
    }
    onSelecciono3 = (itemValue)=>{
        this.setState({
            itemSeleccionado3: itemValue
        })
    }
    fethFiltros = () => {
        fetch('http://192.168.0.97/api/Consultas/GetLibrosFiltrados',{
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'content-Type' : 'application/json',
            },
            body: JSON.stringify({
                IdGenero: this.state.itemSeleccionado,
                IdAutor: this.state.itemSeleccionado2,
                IdEstado: this.state.itemSeleccionado3
            }),
        })
        .then((response) => response.json())
        .then((responseJson) =>{
            this.setState({
                Libros: responseJson
            },function(){});
        })
        .catch((error) =>{
            console.error(error);
        });
    };
    render(){
        let items = this.state.Generos.map((a) => {
            return <Picker.Item label = {a.Genero} value = {a.IdGenero} />;
        });  
        let items2 = this.state.Autores.map((a) => {
            return <Picker.Item label = {a.Nombre + " " + a.Apellido} value = {a.IdAutor} />;
        });  
        let items3 = this.state.Estados.map((a) => {
            return <Picker.Item label = {a.EstadoLectura} value = {a.IdEstadoLectura} />;
        });        
        return (
            <View style={styles.container}>
                <Picker
                    style={{height: 50, width: 200}}
                    selectedValue={this.state.itemSeleccionado}
                    onValueChange={this.onSelecciono}>
                    {items}
                </Picker>
                <Picker
                    style={{height: 50, width: 200}}
                    selectedValue={this.state.itemSeleccionado2}
                    onValueChange={this.onSelecciono2}>
                    {items2}
                </Picker>
                <Picker
                    style={{height: 50, width: 200}}
                    selectedValue={this.state.itemSeleccionado3}
                    onValueChange={this.onSelecciono3}>
                    {items3}
                </Picker>
                <Button
                    title = 'FETCH'
                    onPress = {this.fethFiltros}/>
                <FlatList
                    data= {this.state.Libros}
                    renderItem={({item}) =>
                <Text>{item.Titulo}, {item.Autor}, {item.Genero}, {item.EstadoLectura}
                </Text>}
                keyExtractor={(item, index) => index}
                />
            </View>
        );
    }
}
const styles = StyleSheet.create({
    container: {
      margin: 50,
      flex: 1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });
  