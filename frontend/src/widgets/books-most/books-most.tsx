import BooksMostSkeletons from '~widgets/books-most/books-most-skeletons'

import { Section } from '~packages/ui'

export default function BooksMost() {
	return (
		<Section header={'Сейчас популярно'}>
			<BooksMostSkeletons />
		</Section>
	)
}
