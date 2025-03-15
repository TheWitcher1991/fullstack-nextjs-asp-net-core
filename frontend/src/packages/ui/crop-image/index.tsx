'use client'

import { useCallback, useState } from 'react'
import Cropper, { Area, CropperProps, Point } from 'react-easy-crop'

import { Dialog } from '~packages/ui'
import { cropImage64 } from '~packages/utils'

import styles from './index.module.scss'

interface CropImageProps {
	open: boolean
	onClose: () => void
	image?: CropImageProps['image']
	aspect?: number
	setCropedImage: (image?: string) => void
	cropShape: CropperProps['cropShape']
}

export const CropImage = ({
	image,
	aspect,
	setCropedImage,
	open,
	onClose,
	cropShape,
}: CropImageProps) => {
	const [crop, setCrop] = useState<Point>({
		x: 0,
		y: 0,
	})
	const [zoom, setZoom] = useState<number>(1)
	const [coord, setCoord] = useState<Area>({
		x: 0,
		y: 0,
		width: 0,
		height: 0,
	})

	const onCropComplete = useCallback((_, croppedAreaPixels) => {
		setCoord(croppedAreaPixels)
	}, [])

	const cutImage = () => {
		if (!image) return

		cropImage64(image, coord.x, coord.y, coord.width, coord.height).then(
			croppedImage => {
				setCropedImage(croppedImage)
			},
		)
	}

	const cutHandler = () => {
		cutImage()
		onClose()
	}

	return (
		<>
			<Dialog
				open={open}
				onClose={onClose}
				onClickButtonApply={cutHandler}
				caption={'Вырезать картинку'}
			>
				<div className={styles.crop__container}>
					<Cropper
						cropShape={cropShape}
						image={image}
						crop={crop}
						zoom={zoom}
						showGrid={true}
						aspect={aspect || 1}
						onCropChange={setCrop}
						onZoomChange={setZoom}
						onCropComplete={onCropComplete}
						style={{
							containerStyle: {
								height: '350px',
								borderRadius: '12px',
							},
						}}
					/>
				</div>
			</Dialog>
		</>
	)
}
