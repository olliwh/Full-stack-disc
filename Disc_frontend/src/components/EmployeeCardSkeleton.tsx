import { Card, CardBody, Skeleton, SkeletonText } from "@chakra-ui/react";

const EmployeeCardSkeleton = () => {
  return (
    <Card borderRadius="1" overflow="hidden">
      <Skeleton height="259px" />
      <CardBody>
        <SkeletonText />
      </CardBody>
    </Card>
  );
};

export default EmployeeCardSkeleton;
