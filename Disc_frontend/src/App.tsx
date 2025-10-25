import { Grid, GridItem, Show } from '@chakra-ui/react'
import { NavBar } from './components/NavBar'
import EmployeeGrid from './components/EmployeeGrid'

function App() {

  return (
<Grid
      templateAreas={{ base: `"nav" "main"`, lg: `"nav nav" "aside main"` }}
    >
      <GridItem area="nav" ><NavBar/></GridItem>
      <Show above='lg'>
        <GridItem area="aside" bg="green.500">Aside</GridItem>
      </Show>
      <GridItem area="main">
        <EmployeeGrid/>
        hello
      </GridItem>
    </Grid>
  )
}

export default App
