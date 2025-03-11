import { Skeleton } from '@gravity-ui/uikit'

import BookSkeletonSwiperList from '~features/book-skeleton-swiper-list'

import { Spacing } from '~packages/ui'

export default function BooksByTopicSkeleton() {
	return [...Array(6)].map((_, i) => (
		<div>
			<Skeleton style={{ height: '24px', width: '141px' }} />
			<Spacing v={'xs'} />
			<BookSkeletonSwiperList />
		</div>
	))
}
