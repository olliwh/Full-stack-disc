import { Card, CardBody, Skeleton, SkeletonText } from '@chakra-ui/react'

const EmployeeCardSkeleton = () => {
  return (
    <Card>
        <Skeleton height="259px" />
        <CardBody>
            <SkeletonText/>
        </CardBody>
    </Card>
  )
}

export default EmployeeCardSkeleton