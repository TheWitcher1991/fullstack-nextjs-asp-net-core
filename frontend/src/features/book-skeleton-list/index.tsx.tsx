import { BookFlexSkeleton } from '~models/book'

import 'swiper/swiper-bundle.css'

interface BookSkeletonListProps {
	count?: number
}

export default function BookSkeletonList({
	count = 10,
}: BookSkeletonListProps) {
	return [...Array(count)].map((_, i) => <BookFlexSkeleton key={i} />)
}
