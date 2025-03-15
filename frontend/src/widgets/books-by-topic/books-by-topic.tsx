import BooksByTopicList from '~widgets/books-by-topic/books-by-topic-list'
import BooksByTopicSkeleton from '~widgets/books-by-topic/books-by-topic-skeleton'
import { useBooksByTopicStore } from '~widgets/books-by-topic/books-by-topic.store'

import { RenderFetchData } from '~packages/lib'

export default function BooksByTopic() {
	const { list, loading, count } = useBooksByTopicStore()

	return (
		<RenderFetchData
			isLoading={loading}
			count={count}
			loadingFallback={<BooksByTopicSkeleton />}
		>
			<BooksByTopicList books={list} />
		</RenderFetchData>
	)
}
