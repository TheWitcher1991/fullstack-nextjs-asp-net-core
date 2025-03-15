import BookSwiperList from '~features/book-swiper-list'

import { ITopicBooks } from '~models/book'

import { Section } from '~packages/ui'

interface BooksByTopicListProps {
	books: ITopicBooks[]
}

export default function BooksByTopicList({ books }: BooksByTopicListProps) {
	return books.map(books => (
		<Section key={books.topicId} header={books.topicTitle}>
			<BookSwiperList books={books.books} />
		</Section>
	))
}
