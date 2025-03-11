import { Flex } from '@gravity-ui/uikit'

import { BookSkeleton } from '~models/book'

import 'swiper/swiper-bundle.css'

interface BookSkeletonSwiperListProps {
	count?: number
}

export default function BookSkeletonSwiperList({
	count = 4,
}: BookSkeletonSwiperListProps) {
	return (
		<Flex gap={2}>
			{[...Array(count)].map((_, i) => (
				<BookSkeleton key={i} />
			))}
		</Flex>
	)
}
